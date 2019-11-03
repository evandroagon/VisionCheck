using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace VisionCheck
{
    public sealed class Session

    {
        private static volatile Session instance;
#pragma warning disable IDE0044 // Adicionar modificador somente leitura
        private static object sync = new object();
#pragma warning restore IDE0044 // Adicionar modificador somente leitura

        private Session() { }

        public static Session Instance  //gera uma instancia carregando as variaveis salvas em preferences
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new Session();

                            string my_preferences = "my_preferences";  // nome do repositorio de preferencias personalizado
                            double tamanhoMedido = Preferences.Get("tamanhoMedido_p", 1.2, my_preferences);                        
                            double distancia = Preferences.Get("distancia_p", 40.0, my_preferences);             
                            double fator = Preferences.Get("fator_p", 1.0, my_preferences);                      
                            double tamanho = Preferences.Get("tamanho_p", 100.0, my_preferences);                    

                            Session.Instance.UserDistancia = distancia; //em metros
                            Session.Instance.UserFator = fator; //relação entre tamanho medido e tamanho esperado
                            Session.Instance.UserTamanho = tamanho;
                            Session.Instance.UserTamanhoMedido = tamanhoMedido;
                            
                        }
                    }
                }
               
                return instance;
            }

        }

        /// <summary>
        /// Propriedade para o ID do usuario
        /// </summary>
        public int UserID { get; set; }
        public double UserTamanho { get; set; }
        public double UserTamanhoMedido { get; set; }
        public double UserDistancia { get; set; }
        public double UserFator { get; set; }

   

        public List<VetTamanhos> CriarVetTamanhos()
        {
             var  varTamanhos = new List<VetTamanhos>
           {
                new VetTamanhos() { value = 15.0/20, name = "20/15",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/20, name = "20/20",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 30.0/20, name = "20/30",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 40.0/20, name = "20/40",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 50.0/20, name = "20/50",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 60.0/20, name = "20/60",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 70.0/20, name = "20/70",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 80.0/20, name = "20/80",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 100.0/20, name = "20/100", resposta = "", angulo=0.0},
                new VetTamanhos() { value = 200.0/20, name = "20/200", resposta = "", angulo=0.0},
                new VetTamanhos() { value = 300.0/20, name = "20/300", resposta = "", angulo=0.0},
                new VetTamanhos() { value = 400.0/20, name = "20/400", resposta = "", angulo=0.0}

            };
            
        return varTamanhos;


        }



        public class VetTamanhos
        {
            public string name { get; set; }
            public double value { get; set; }
            public double angulo { get; set; }
            public string resposta { get; set; }

        }



    }
}
