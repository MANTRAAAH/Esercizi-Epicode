using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio_BackEnd_S1L3
{
    internal class ContoCorrente
    {
        private bool _isAttivo;
        private decimal _saldo;

        public ContoCorrente()
        {
            _isAttivo = false;
            _saldo = 0;
            
        }

        public void AttivaConto(decimal primoVersamento)
        {
            if (!_isAttivo && primoVersamento >= 1000)
            {
                _isAttivo = true;
                _saldo += primoVersamento;
                Console.WriteLine("Conto attivato con successo");
            }
            else
            {
                Console.WriteLine("Conto non attivato");
            }

        }

        public void Versa(decimal importo)
        {
            if (_isAttivo)
            {
                _saldo += importo;
                Console.WriteLine($"Versamento di {importo} euro effettuato con successo, il saldo è di {_saldo}");
            }
            else
            {
                Console.WriteLine("Conto non attivo");
            }

        }

        public void Preleva(decimal importo)
        {
            if (_isAttivo && importo <= _saldo)
            {
                _saldo -= importo;
                Console.WriteLine($"Prelevamento di {importo} euro effettuato con successo, il saldo è di {_saldo}");
            }
            else if (!_isAttivo)
            {
                Console.WriteLine("Conto non attivo");
            }
            else
            {
                Console.WriteLine("Saldo insufficiente");
            }
        }
        public void visualizzaSaldo()
        {
            Console.WriteLine($"Il saldo attuale è di {_saldo}");
        }
    }
 
}
