using ecommerce_app.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_app.Services.IntroducaoServices
{
    public class IntroducaoServices : IIntroducaoServices
    {

        public List<IntroducaoModel> Get_Introducao()
        {
            return new List<IntroducaoModel>()
            {
                new IntroducaoModel()
                {
                    Titulo = "Bem Vindo(a)",
                    Imagem = "bem_vindo.png", // animação lottie https://lottie.host/83d69432-2170-4653-9969-bd2c770d85f0/Hq52NBc4Ov.json 
                    Descricao = "Bem-vindo ao E-Commerce App!Explore, descubra e compre com facilidade em nossa plataforma de ecommerce. " +
                    "Oferecemos uma ampla seleção de produtos e uma experiência de compra segura. Comece a explorar agora!" //\r\n pular linha
                },
                new IntroducaoModel()
                {
                    Titulo = "Sobre",
                    Imagem = "sobre_nos.png", // https://lottie.host/1cbef255-847a-4b28-be8b-0930fc5f4119/Ma0jZ1BrY2.json
                    Descricao = "Somos apaixonados por proporcionar uma experiência de compra online excepcional. No E-Commerce App, buscamos oferecer conveniência, variedade e qualidade em cada clique. " +
                    "Nossa missão é simplificar sua jornada de compras, proporcionando acesso fácil aos produtos que você ama. " +
                    "Explore nosso aplicativo, encontre ofertas exclusivas e desfrute de uma experiência de compra sem complicações. Estamos aqui para tornar sua vida mais fácil, um clique de cada vez."
                },
                new IntroducaoModel()
                {
                    Titulo = "Consentimento de Conteúdo e Acordo do Usuário",
                    Imagem = "contrato.png", //https://lottie.host/3ea046eb-1f35-4ab4-ad32-f69f314893b9/cHZd8b6FEV.json
                    Descricao = "Ao utilizar o E-Commerce App. você concorda em respeitar nossos termos e condições. Isso inclui consentir com a coleta e o uso de seus dados pessoais de acordo com nossa política de privacidade. " +
                    "Garantimos que seus dados serão tratados com segurança e confidencialidade. Além disso, ao acessar nosso aplicativo, você concorda em receber comunicações relacionadas a produtos, promoções e atualizações importantes. " +
                    "Se tiver alguma dúvida sobre nossas políticas, entre em contato conosco. Agradecemos por confiar em nós para suas necessidades de compras online."
                },
                new IntroducaoModel()
                {
                    Titulo = "Parabéns!",
                    Imagem = "parabens.png", // https://lottie.host/f9a87006-d47f-4c73-9036-dae28d1aa797/vBgU4Y6wml.json
                    Descricao = "Você chegou ao final da nossa introdução. Estamos entusiasmados para efetuar compras em nossa aplicação. " +
                    "Obrigado por nos escolher!\r\nMuitas felicidades,\r\nE-Commerce App"
                }
            };

        }

    }
}
