namespace AceiteDigitalApp.Domain.Entities
{
    /// <summary>
    /// Operações realizadas no documento.
    /// </summary>
    public enum TipoEvento
    {
        /// <summary>
        /// Quando um documento é criado.
        /// </summary>
        Criado,

        /// <summary>
        /// Quando um documento recebe um signatário.
        /// </summary>
        AdicionadoSignatario,

        /// <summary>
        /// Quando um signatário efetua o aceite ou recusa.
        /// </summary>
        Assinado
    }
}
