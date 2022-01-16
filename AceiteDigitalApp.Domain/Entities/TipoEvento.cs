using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
