using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjBau
{
    internal class Player
    {
        #region Propriedades

        private string _nome { get; set; }

		public string GetNome()
		{
			return _nome;
		}

		public void SetNome(string nome)
		{
            if(!String.IsNullOrEmpty(nome))
            {                
			    _nome = nome;
            }
            else
            {
                throw new Exception("O nome precisa ser preenchido");
            }
		}

        private int _vida { get; set; }

        public int GetVida()
        {
            return _vida;
        }

        public void SetVida(int hp)
        {
            if(hp > 100)
            {
                _vida = 100;
            }
            else
            {
                _vida = hp;
            }
        }

        private int _qtMoedas { get; set; }

        public int GetMoedas()
        {
            return _qtMoedas;
        }

        public void SetMoedas(int moeda)
        {
            _qtMoedas = moeda;
        }

		public Item item;

        #endregion

        #region Métodos

        public string tentarAbrir(string numero)
		{
			if(item != null)
            {

				if (item.Nome == "Chave" + numero)
				{
					return "Abrindo";
				}
				else
				{
					return "Sem chave";
				}
            }
			else
            {
				return "Sem chave";
            }

		}

		public void usaPocao()
		{
			item = null;
            this.SetVida(GetVida() + 10);
		}

        #endregion

        #region Constructors

        public Player(string nome, int hp, Item item, int moedas)
		{
			this.SetNome(nome);
			this.SetVida(hp);
			this.item = item;
            this.SetMoedas(moedas);
		}

        #endregion
    }
}
