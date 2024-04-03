namespace PassIn.Exceptions
{
    public class PassInException : SystemException
    {
        // Pega a mensagem recebida e passa para o construtor da classe herdada, no caso o SystemException
        public PassInException(string message) : base(message) { }
    }
}
