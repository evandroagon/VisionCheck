using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace VisionCheck.Models
{
    public sealed class imagem
    {

        private static volatile imagem instance;
        public static List<VetImagens> T;
        private static object sync = new object();

        private imagem() { }

        public static imagem Instance
        {
            get
            {
                if (instance == null)
                {

                    lock (sync)
                    {
                        {
                            
                            instance = new imagem();
                                                      

                        }
                    }
                }


                return instance;

            }


        }

       
       public bool atualizarVet(int i, string resposta)            
       {    varImagem[i].resposta = resposta;
            return true;
        }

        public static ObservableCollection<VetImagens>         
          varImagem = new ObservableCollection<VetImagens>
       
            {
                new VetImagens() { id = "1", value = "ishihara_01.jpg", normal = "12",
                                    daltonico = "12", total = "12", fake = "", resposta = "" },

                 new VetImagens() { id = "2", value = "ishihara_02.jpg", normal = "8",
                                    daltonico = "3", total = "x", fake = "9", resposta = "" },

                 new VetImagens() { id = "3", value = "ishihara_03.jpg", normal = "29",
                                    daltonico = "70", total = "x", fake = "96", resposta = "" },

                 new VetImagens() { id = "4", value = "ishihara_04.jpg", normal = "5",
                                daltonico = "2", total = "x", fake = "3", resposta = "" },

                 new VetImagens() { id = "5", value = "ishihara_05.jpg", normal = "3",
                     daltonico = "5", total = "x", fake = "6", resposta = "" },
                 new VetImagens() { id = "6", value = "ishihara_06.jpg", normal = "15",
                     daltonico = "17", total = "x", fake = "12", resposta = "" },
                 new VetImagens() { id = "7", value = "ishihara_07.jpg", normal = "74",
                     daltonico = "21", total = "x", fake = "17", resposta = "" },
                 new VetImagens() { id = "8", value = "ishihara_08.jpg", normal = "6",
                     daltonico = "8", total = "x", fake = "5", resposta = "" },
                 new VetImagens() { id = "9", value = "ishihara_09.jpg", normal = "45",
                     daltonico = "12", total = "x", fake = "73", resposta = "" },
                 new VetImagens() { id = "10", value = "ishihara_10.jpg", normal = "5",
                     daltonico = "3", total = "x", fake = "2", resposta = "" },
                 new VetImagens() { id = "11", value = "ishihara_11.jpg", normal = "7",
                     daltonico = "2", total = "x", fake = "4", resposta = "" },
                 new VetImagens() { id = "12", value = "ishihara_12.jpg", normal = "16",
                     daltonico = "70", total = "x", fake = "45", resposta = "" },
                 new VetImagens() { id = "13", value = "ishihara_13.jpg", normal = "73",
                     daltonico = "15", total = "x", fake = "42", resposta = "" }, 
                 new VetImagens() { id = "14", value = "ishihara_14.jpg", normal = "2",
                     daltonico = "5", total = "x", fake = "6", resposta = "" }, 
                 new VetImagens() { id = "15", value = "ishihara_15.jpg", normal = "15",
                     daltonico = "45", total = "x", fake = "42", resposta = "" }, 
                 new VetImagens() { id = "16", value = "ishihara_16.jpg", normal = "26",
                     daltonico = "2", total = "", fake = "6", resposta = "" }, 
                 new VetImagens() { id = "17", value = "ishihara_17.jpg", normal = "42",
                     daltonico = "4", total = "", fake = "4", resposta = "" },
                 new VetImagens() { id = "18", value = "ishihara_18.jpg", normal = "Ambas",
                     daltonico = "Linha Vermelha", total = "", fake = "Linha Roxa", resposta = "" },
                 new VetImagens() { id = "19", value = "ishihara_19.jpg", normal = "Pontos Coloridos",
                     daltonico = "Linha Esverdeada", total = "", fake = "Triangulo Azul", resposta = "" },
                 new VetImagens() { id = "20", value = "ishihara_20.jpg", normal = "Linha",
                     daltonico = "Aspiral", total = "", fake = "Estrela", resposta = "" },
                 new VetImagens() { id = "21", value = "ishihara_21.jpg", normal = "Linha Laranja",
                     daltonico = "Circulo Verde", total = "", fake = "Circulo Vermelho", resposta = "" },
                 new VetImagens() { id = "22", value = "ishihara_22.jpg", normal = "Linha Amarelo-esverdeada",
                     daltonico = "Linha Verde-azulada", total = "", fake = "Linha Roxa", resposta = "" },
                 new VetImagens() { id = "23", value = "ishihara_23.jpg", normal = "Linha Laranja/vermelha",
                     daltonico = "Linha Azul-esverdeada ou Roxa", total = "", fake = "Linha Amarelo-esverdeada", resposta = "" },
                 new VetImagens() { id = "24", value = "ishihara_24.jpg", normal = "Linha Laranja",
                     daltonico = "Linha Verde", total = "", fake = "Ambas", resposta = "" },

             };
                                
        }


        public class VetImagens
        {
            public string id { get; set; }  // numero sequencial da imagem
            public string value { get; set; } //nome do arquivo fisico da imagem
            public string normal { get; set; } // resposta normais
            public string daltonico { get; set; } // resposta daltonicos
            public string total { get; set; } //resposta perda total de cores
            public string resposta { get; set; } //resposta a ser recebida do paciente
            public string fake { get; set; } // resposta falsa ninguém deve responder

        }
    }


    







    
    

