using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eventos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // EVENTOS: 
        
        // Crie 3 botões e quatro paineis igual ao exemplo. Defina todas as propriedades "Name" como: 
        // btn1, btn2 e btn3, panelBlue, panelRed, panelYellow e panelGren. Mude também os Text dos 
        // botões e as backcolor dos paineis.

        // Eventos por defeito. Se der um duplo clique num qualquer objeto entrará para a codificação do
        // seu evento por defeito. Experimente no botão e depois num painel
        // No botão é o clique e no painel é o paint. Repare nos nomes dos métodos
        //    -> private void btn1_Click(object sender, EventArgs e)
        //    -> private void panelBlue_Paint(object sender, PaintEventArgs e)
        
        // Um tem o nome do botão e o nome do evento "Click e o outro tem o nome do panel e o evento "Paint"
        // Falaremos dos parametros mais tarde.
        
        // Mas como chamar outro qualquer evento para o botão ou para o painel, ou outro objeto qualquer?
        // Simples. Muito simples...
        // Podemos programar qualquer evento num qualquer objeto. Para tal temos de dar 2 pequenos passos:
        // 1º selecionar o objeto no DESIGN (na form). Pode ser o painel mais à esquerda.
        // 2º escolher o evento a codificar. Nas propriedades do objeto, em cima. há vários icon: interessam dois
        // para já: um com uma lista outro com um raio. A lista contém as proprieades que já conhecem. O raio
        // contém os eventos disponíveis. Verifique que o evento pré selecionado é o PAint. E tem até um nome associado.
        // É precisamente o do método criado com o duplo clique de há pouco. 
        // Pretendemos pintar o btn1 com a mesma cor do painel criado. Vamos codificar isso mesmo no evento "click
        // Localize o evento "Click" e de-lhe duplo clique. Entrará para o seu método e poderá codificar o que pretende 
        // que ele faça, ou seja que o btn1 receba a cor do painel.

        //*******************************************************************************************
        // Botões e eventos


        // evento por defeito é o click, mas podemos escolher qualquer outro na sua lista de eventos
        private void btn1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("olá click");
        }

        // este evento apenas muda o nome do btn3
        private void btn2_Click(object sender, EventArgs e)
        {
            btn3.Text = "Clica-me";
        }

        // O evento seguinte faz mover o botão 3, com o evento mouse over
        // Sempre que o rato entra no espaço do botão, as suas propriedades top e left
        // são recalculadas aleatóriamente.
        private void btn3_MouseHover(object sender, EventArgs e)
        {
            Random rand = new Random();         // novo objeto aleatório criado
            btn3.Top = rand.Next() % 200;       // Nova distancia ao topo
            btn3.Left = rand.Next() % 200;      // Nova distancia à esquerda
        }


        //*************************************************************************************************
        // Eventos com paineis.

        // opção1: um objeto, um método
        // O painel tem um evento por defeito chamado Paint. Contudo queremos ter uma palete de cores
        // que uma vez selecionala, pinta a cor do botão com a respetiva cor.
        // Então usamos o evento click de cada panel, para alterar a propriedade backcolor do btn1.

        //private void panelRed_Click(object sender, EventArgs e)
        //{
        //    btn1.BackColor = color.red;   // O botão pode receber a cor red.
        //}

        //private void panelGren_Click(object sender, EventArgs e)
        //{
        //    btn1.BackColor = color.green;   // O botão pode receber a cor red.
        //}

        //private void panelYellow_Click(object sender, EventArgs e)
        //{
        //    btn1.BackColor = color.yellow;   // O botão pode receber a cor red.
        //}

        //private void panelBlue_Click(object sender, EventArgs e)
        //{
        //    btn1.BackColor = color.blue;   // O botão pode receber a cor red.
        //}




        // opção 2: Vários objetos, um só método:
        private void panelCor_Click(object sender, EventArgs e)
        {
            btn1.BackColor = ((Panel)sender).BackColor;   // O btn 1 recebe a cor do objeto que disparou o evento
            // Notar em: ((Panel)sender)
            // É a 1ª execução que ocorre e converte o "sender" que é do tipo object, para o tipo Panel
            // Isto é necssário porque object é um tipo que aceita qualquer objeto, todos os objetos, e 
            // o problema é que os objetos específicos, como o botão ou o menu, têm propriedades específicas
            // diferentes do painel.  
            // Usando o tipo Object, definimos que aceitamos qualquer objeto específico naquele 1º parametro,
            // Como sabemos que vai ser um painel, e para aceder às suas propriedades, só temos de converter
            // e isso faz-se assim: (Panel)sender. 
            // Este tipo de conversão chama-se "cast", colocamos o tipo de conversão (Panel) antes da var a 
            // converter "sender". Da mesma forma Podemos converter um float para int:
            // float a; 
            // int b = (int)a; 

            // Só falta perceber porque é que há dois parenteses: É apenas para forçar que a conversão
            // se execute primeiro, antes de aceder às suas propriedades.
            // O código desta linha executa primeiro tudo o que está à direita do sinal de atribuição "=".
            // Na direita executa primeiro o que esté no mais centro dos parenteses e evolui para fora.
            // Só depois é que atribui o resultado à parte esquerda da atribuição "=".
            // Ou seja: converte o object sender para Painel e acede à propriedade Backcolor que a atribui
            // à propriedade BackColor do botão btn1. Simples não é?
        }

      

        //******************************************************************************************
        // Multiplos disparos de eventos, um só método.
        // Neste exercício temos 24 paineis e queremos que a borda passe para relevo 3D quando o rato
        // entra na sua zona e passe a borda simples quando o rato sair da sua zona. Isto criará um efeito
        // 3D interessante ao passar com o rato sobre os vários paineis.
        // 1 - Criar um painel pequeno de cor branca e mudar o seu "Name" para panelGeral.
        // 2 - Localizar o evento MouseEnter e com duplo clique, criar e entrar para o seu método.
        // 3 - Criar o seguinte código.

        private void panelGeral_MouseEnter(object sender, EventArgs e)
        {
            ((Panel)sender).BorderStyle = BorderStyle.Fixed3D;
        }

        // 4 - Voltar ao modo design e localizar o evento "Mouseleave"no mesmo painel "PanelGeral". 
        // Duplo clique e copiar o código seguinte.

        private void panelGeral_MouseLeave(object sender, EventArgs e)
        {
            ((Panel)sender).BorderStyle = BorderStyle.FixedSingle;
        }

        // Em Design, copiar o panelGeral e duplicar 17 vezes. Organiza-los em 3 linhas, 
        // bem alinhados debaixo dos paineis de cor do exercicio anterior.
        // Usando o rato, selecionar todos estes pequenos paineis de uma só vez e verificar se 
        // os métodos que estão associados aos eventos MouseEnter e MouseLeave são estes.
        // Notar que apesar de termos 17 paineis, todos os seus eventos MouseEnter e MouseLeave têm
        // que estar associados a estes dois métodos: panelGeral_MouseEnter() e panelGeral_MouseLeave().
        // Caso contrário não funciona.

        // Uma ultima nota para o código nestes dois métodos.
        // Como se pretende um método que faz exatamente a mesma coisa para servir uma série de objetos, 
        // não faz sentido ir a cada objeto e dar duplo clique em cada evento para criar 17 métodos que 
        // fazem a mesma coisa. Desperdício de tempo e código.
        // Assim precisamos apenas de identificar o Objeto que provoca o disparo do evento, o que pode ser
        // feito através do parametro "object sender". Como este parametro recebe um objeto "Base", temos apenas 
        // de o converter para o objeto específico (Panel), de forma a podermos aceder às suas propriedades específicas:
        // Panel p = (Panel)sender; faz isso mesmo converte o object sender para Panel e atribui-o a p, que é um Panel local.
        // está feito.

              

        //*******************************************************************************************
        // teclas e eventos

        // No caso seguinte o evento disparado é quando uma tecla é carregada, mas queremos 
        // associa-lo ao botão btn1. Esquisito? pode ser, mas há vantagens.
        // 1 - Em design Selecionar o botão 1 e escolher o eventor keyDown - > duplo clique.
        // Observar nos parametros que o argumento que vai passar é o "keyargumentArgs" e não o EventArgs. 
        // Então, apesar do objeto ser um botão, o evento keyDown irá ouvir as teclas. (key listener).
        // Se o btn1 for o objeto ativo, será ele o emissor. Se for o btn2, será este o objeto emissor. 
        // Isto pode ser útil, por exemplo, se quisermos escrever texto numa de várias caixas de texto, 
        // apenas se um determinado objeto, como um botão ou um painel, estiver ativo.
        private void btn1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("olá btn1 keydown diz que a tecla foi:" + " " + e.KeyCode);
        }

        // Portanto, podemos associar um qualquer evento a um qualquer objeto. Potente hem?

        private void btn2_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("olá btn2 keydown" + " " + e.KeyCode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
        

    }
}
