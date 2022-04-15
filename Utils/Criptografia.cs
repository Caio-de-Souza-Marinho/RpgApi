namespace RpgApi.Utils
{
    public class Criptografia
    {
        public static void CriarPasswordHash(string password, out byte[] hash, out byte [] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //Método que recebe a senha como uma string simples e compara com o que está na base de dados.
        public static bool VerificarPasswordHash(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var computeHash = 
        hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i=0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}