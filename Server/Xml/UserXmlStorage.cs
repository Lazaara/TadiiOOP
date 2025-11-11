using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Server.Xml;

public static class UserXmlStorage {
    public static readonly XmlSerializer Serializer = new(typeof(List<User>));
    public static readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.xml");

    /// <summary>Loads all users from the XML file.</summary>
    public static List<User> LoadAll() {
        if (!File.Exists(FilePath))
            return new List<User>();

        try {
            using var stream = new FileStream(FilePath, FileMode.Open);
            return (List<User>)Serializer.Deserialize(stream)!;
        }
        catch {
            return new List<User>();
        }
    }

    /// <summary>Saves all users back to XML.</summary>
    public static void SaveAll(List<User> users) {
        Directory.CreateDirectory(Path.GetDirectoryName(FilePath)!);
        using FileStream stream = new FileStream(FilePath, FileMode.Create);
        Serializer.Serialize(stream, users);
    }

    /// <summary>Finds a user by their email (case-insensitive).</summary>
    public static User? GetUserByEmail(string email) {
        if (string.IsNullOrWhiteSpace(email)) return null;

        List<User> users = LoadAll();
        return users.FirstOrDefault(u =>
            string.Equals(u.Email, email.Trim(), StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>Adds or updates a user.</summary>
    public static void UpsertUser(User user) {
        List<User> users = LoadAll();
        User? existing = users.FirstOrDefault(u =>
            string.Equals(u.Email, user.Email, StringComparison.OrdinalIgnoreCase));

        if (existing != null) {
            existing.PasswordHash = user.PasswordHash;
            existing.IsOnline = user.IsOnline;
        }
        else {
            users.Add(user);
        }

        SaveAll(users);
    }
}