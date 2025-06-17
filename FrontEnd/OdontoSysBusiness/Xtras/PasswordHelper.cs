using System;
using System.Security.Cryptography;
using System.Text;

namespace OdontoSysWebApplication.Xtras
{
    public static class PasswordHelper
    {
        /// <summary>
        /// Genera un hash determinista SHA-256 de la contraseña en forma de cadena hexadecimal.
        /// </summary>
        /// <param name="password">Contraseña en texto claro.</param>
        /// <returns>Hash hex (64 caracteres).</returns>
        public static string HashPassword(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            // 1) Obtener bytes UTF8 de la contraseña
            byte[] pwdBytes = Encoding.UTF8.GetBytes(password);

            // 2) Calcular SHA-256
            using (var sha = SHA256.Create())
            {
                byte[] hashBytes = sha.ComputeHash(pwdBytes);

                // 3) Convertir a hex
                var sb = new StringBuilder(64);
                foreach (byte b in hashBytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        /// <summary>
        /// Verifica que la contraseña en claro, al hashearse, coincida con el hash almacenado.
        /// </summary>
        /// <param name="password">Contraseña en texto claro.</param>
        /// <param name="storedHash">Hash hex almacenado.</param>
        /// <returns>True si coinciden; false en caso contrario.</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (storedHash == null) throw new ArgumentNullException(nameof(storedHash));

            // Genera el hash de entrada y compara en tiempo fijo
            string computed = HashPassword(password);
            return FixedTimeEquals(computed, storedHash);
        }

        /// <summary>
        /// Comparación en “tiempo fijo” de dos cadenas hex para evitar fugas por temporización.
        /// </summary>
        private static bool FixedTimeEquals(string a, string b)
        {
            if (a.Length != b.Length) return false;

            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];

            return diff == 0;
        }
    }
}