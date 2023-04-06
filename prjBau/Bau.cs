using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBau
{
    internal class Bau
    {
        #region Propriedades

        private bool _trancado;

        public bool Trancado 
        {
            get { return _trancado; }
            set 
            {
                if (!value || value)
                    _trancado = value;
                else
                    throw new Exception("deu erado :(");
            }
        }

        private bool _aberto;

        public bool Aberto
        {
            get { return _aberto; }
            set
            {
                if (!value || value)
                    _aberto= value;
                else
                    throw new Exception("deu erado :(");
            }
        }

        private int _valorMoedas;

        public int ValorMoedas
        {
            get { return _valorMoedas;}
            set {
                if (!String.IsNullOrEmpty(value.ToString()))
                {
                    try
                    {
                        if(value <= 200)
                        {
                            _valorMoedas = value;
                        }
                        else
                        {
                            throw new Exception("Valor da moeda deve ser até 200");
                        }
                    }
                    catch 
                    {
                        throw new Exception("Valor de moedas deve ser numérico!!");
                    }
                }
                else
                    throw new Exception("Insira o valor das moedas");
            }
        }

        #endregion

        #region Métodos

        public string tentarAbrir()
        {
            if(!Aberto)
            {
                if(Trancado)
                {
                    return "Ta trancado";
                }
                else
                {
                    Aberto = true;
                    return "Abrindo baú, você recebeu " + ValorMoedas + " Moedas";
                }
            }
            else
            {
                return "Baú já está aberto";
            }
        }

        public string abrirBau()
        {
            Trancado = false;
            Aberto = true;
            return "Baú aberto, você recebeu " + ValorMoedas + " Moedas";
        }

        #endregion

        #region Constructors

        public Bau (bool trancado, bool aberto, int moedas)
        {
            this.Trancado = trancado;
            this.Aberto = aberto;
            this.ValorMoedas = moedas;
        }

        #endregion

    }
}
