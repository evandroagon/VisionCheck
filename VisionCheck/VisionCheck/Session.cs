using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace VisionCheck
{
    public sealed class Session

    {
        private static volatile Session instance;

        public static List<VetTamanhos> T;
        //#pragma warning disable IDE0044 // Adicionar modificador somente leitura
        private static object sync = new object();
        //#pragma warning restore IDE0044 // Adicionar modificador somente leitura

        private Session() { }

        public static Session Instance  //gera uma instancia carregando as variaveis salvas em preferences
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {

                        instance = new Session();

                        string my_preferences = "my_preferences";  // nome do repositorio de preferencias personalizado
                        double tamanhoMedido = Preferences.Get("tamanhoMedido_p", 1.2, my_preferences);
                        double distancia = Preferences.Get("distancia_p", 40.0, my_preferences);
                        double fator = Preferences.Get("fator_p", 1.0, my_preferences);
                        double tamanho = Preferences.Get("tamanho_p", 100.0, my_preferences);
                        bool contrasteAlto = Preferences.Get("contraste_alto_p", true, my_preferences);
                        bool mostrarEsc = Preferences.Get("mostrar_esc", true, my_preferences);
                        bool mostrarDist = Preferences.Get("mostrar_distancia", true, my_preferences);

                        Session.Instance.UserDistancia = distancia; //em metros
                        Session.Instance.UserFator = fator; //relação entre tamanho medido e tamanho esperado
                        Session.Instance.UserTamanho = tamanho;  // fonte para o 20/400 já calibrada
                        Session.Instance.UserTamanhoMedido = tamanhoMedido;
                        Session.Instance.UserContrasteAlto = contrasteAlto;
                        Session.Instance.UserMostrarEsc = mostrarEsc;
                        Session.Instance.UserMostrarDist = mostrarDist;


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
        public bool UserContrasteAlto { get; set; }
        public bool UserMostrarEsc { get; set; }
        public bool UserMostrarDist { get; set; }


        public bool AtualizarTamanhos(int i, string resposta)

        {

            varTamanhos[i].resposta = resposta;
            return true;
        }


        // alteração
        public static List<VetTamanhos> //CriarVetTAmanhos()
     //   { 
          varTamanhos = new List<VetTamanhos>
            

        //public List<VetTamanhos> CriarVetTamanhos() // versão anterior
       // {
         //    var  varTamanhos = new List<VetTamanhos>  //versão anterior
           {
                new VetTamanhos() { value =  20.0/16.0, name = "20/16",   resposta = "", angulo=0.0},
                new VetTamanhos() { value =  20.0/20.0, name = "20/20",   resposta = "", angulo=0.0},
                new VetTamanhos() { value =  20.0/25.0, name = "20/25",   resposta = "", angulo=0.0},
                new VetTamanhos() { value =  20.0/32.0, name = "20/32",   resposta = "", angulo=0.0},
                new VetTamanhos() { value =  20.0/40.0, name = "20/40",   resposta = "", angulo=0.0},
                new VetTamanhos() { value =  20.0/50.0, name = "20/50",   resposta = "", angulo=0.0},
                new VetTamanhos() { value =  20.0/63.0, name = "20/63",   resposta = "", angulo=0.0},
                new VetTamanhos() { value =  20.0/80.0, name = "20/80",   resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/100.0, name = "20/100",  resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/125.0, name = "20/125",  resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/160.0, name = "20/160",  resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/200.0, name = "20/200",  resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/250.0, name = "20/250",  resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/320.0, name = "20/320",  resposta = "", angulo=0.0},
                new VetTamanhos() { value = 20.0/400.0, name = "20/400",  resposta = "", angulo=0.0},
            };
    

           // return varTamanhos;
            
        
        }


   


        public class VetTamanhos
        {
            public string name { get; set; }
            public double value { get; set; }
            public double angulo { get; set; }
            public string resposta { get; set; }

        }



    }

