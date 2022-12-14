namespace STC.Utils
{
    public class UtilMessages
    {
        #region Information

        public static string information01XE01(Exception ex) =>
            $"01XE01 - TimeOut, Processamento tomou mais tempo do que o permitido | {ex.Message} |";

        #endregion

        #region User

        public static string user02XE01(Exception ex) => $"02XE01 - Falha interna no servidor - | {ex.Message} |";

        public static string user02XE02(Exception ex) =>
            $"02XE02 -  Este E-mail já está cadastrado ou falha ao incluir o usuario - | {ex.Message} |";

        public static string user02XE03() => $"02XE03 - Usuário ou senha inválida";
        public static string user02XE04() => $"02XE04 - Senha inválida";
        public static string user02XE05() => "02XE05 - Email já cadastrado";
        public static string user02XE06(int userId) => $"02XE06 - Usuário não encontrado - '{userId}'";

        #endregion
    }
}