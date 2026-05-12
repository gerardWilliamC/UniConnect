using UniConnect.Models;

namespace UniConnect.Database
{
    /// <summary>
    /// Stores the currently logged-in user across all forms in the application.
    /// Set this on successful login; read it from any form that needs to know
    /// who's signed in.
    /// </summary>
    public static class Session
    {
        public static Student CurrentStudent { get; set; }
        public static Admin CurrentAdmin { get; set; }

        /// <summary>True if a student is currently logged in.</summary>
        public static bool IsStudent => CurrentStudent != null;

        /// <summary>True if an admin is currently logged in.</summary>
        public static bool IsAdmin => CurrentAdmin != null;

        /// <summary>Clears all session data. Call when logging out.</summary>
        public static void Clear()
        {
            CurrentStudent = null;
            CurrentAdmin = null;
        }
    }
}