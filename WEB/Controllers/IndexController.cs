using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using WEB.Models;

namespace WEB.Controllers
{
    public class IndexController : Controller
    {
        #region[Controller - Index]
        public IActionResult Index()
        {
            try
            {
                List<Imagem> listaImg = new List<Imagem>();

                var path = "../WEB/BibliotecaImagens/BibliotecaImg.csv";
                TextFieldParser csvParser = new TextFieldParser(path);

                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { ";" });
                csvParser.HasFieldsEnclosedInQuotes = true;

                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();

                    if (fields[1] != "")
                    {
                        Imagem img = new Imagem();
                        img.Nome = fields[0].Trim().ToString();
                        img.FilePath = fields[1].Trim().ToString();
                        img.Descricao = fields[2].Trim().ToString();

                        listaImg.Add(img);
                    }
                }


                ViewBag.imagem = listaImg;
                    
               




                return View(listaImg); //View tipada
            }
            catch (Exception e)
            {
                throw new Exception
                    (
                        string.Format("Ocorreu um erro ao carregar as fotos, contate o Eder, ou verifique o arquivo .csv - ERRORMESSAGE: \"{0}\"",
                        e.Message), e 
                    ); 
            }
           
        }
        #endregion
    }
}