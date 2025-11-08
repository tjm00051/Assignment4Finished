using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Assignment3
{
    public partial class Assignment3Form : Form
    {
        private Deck deck;
        private Card[] hand=new Card[5];
        private ImageList imageListCards=new ImageList();
        private OpenFileDialog openFileDialog=new OpenFileDialog();
        private SaveFileDialog saveFileDialog=new SaveFileDialog();
        private CheckBox[] keepBoxes;
        private PictureBox[] cardBoxes;
        private DeckForm? deckFormInstance=null;
        public Assignment3Form()
        {
            InitializeComponent();
            deck=new Deck(imageListCards);
            for(int i=0;i<hand.Length;i++)hand[i]=Card.NoCard;
        }
        private void checkBox1_CheckedChanged(object sender,EventArgs e)
        {
        }
        private void Assignment3Form_Load(object sender,EventArgs e)
        {
            keepBoxes=new CheckBox[]{chkKeep1,chkKeep2,chkKeep3,chkKeep4,chkKeep5 };
            cardBoxes=new PictureBox[]{picCard1,picCard2,picCard3,picCard4,picCard5 };
            LoadCardImages();
            this.MaximizeBox=false;
            this.FormBorderStyle=FormBorderStyle.FixedDialog;
            btnDeal.Text="&Deal";
            btnSave.Text="&Save Hand";
            btnLoad.Text="&Load Hand";
            chkKeep1.Text="&Keep 1";
            chkKeep2.Text="&Keep 2";
            chkKeep3.Text="&Keep 3";
            chkKeep4.Text="&Keep 4";
            chkKeep5.Text="&Keep 5";
            deck.Shuffle();
            UpdateHandPictureBoxes();
        }
        private void btnDeal_Click(object sender,EventArgs e)
        {
            DealNewHand();
        }
        private void DealNewHand()
        {
            deck.Shuffle();
            for(int i=0;i<hand.Length;i++)
            {
                if(!keepBoxes[i].Checked)continue;
                var keptCard=hand[i];
                if(keptCard!=null&&keptCard.Id>=0)
                {
                    deck.RemoveCardById(keptCard.Id);
                }
            }
            for(int i=0;i<5;i++)
            {
                if(!keepBoxes[i].Checked)
                {
                    hand[i]=deck.DealCard();
                }
            }
            UpdateHandPictureBoxes();
            deckFormInstance?.UpdateDeck();
        }
        private void LoadCardImages()
        {
            imageListCards.ImageSize=new Size(120,170);
            string cardPath=Path.Combine(Application.StartupPath,"cards");
            if(Directory.Exists(cardPath))
            {
                imageListCards.Images.Clear();
                var files =Directory.GetFiles(cardPath,"*.png");
                Array.Sort(files); 
                for(int i=0;i<files.Length;i++)
                {
                    string file=files[i];
                    try
                    {
                        var img=Image.FromFile(file);
                        string key=Path.GetFileNameWithoutExtension(file);
                        imageListCards.Images.Add(key,img);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                MessageBox.Show("Card images folder not found! Place a 'cards' folder next to your .exe file.");
            }
        }
        private void picCard_Click(object sender,EventArgs e)
        {
            PictureBox clicked=sender as PictureBox;
            if (clicked==null) return;
            int index=Array.IndexOf(cardBoxes,clicked);
            if (index>=0)
            {
                keepBoxes[index].Checked=!keepBoxes[index].Checked;
            }
        }
        private void btnLoad_Click(object sender,EventArgs e)
        {
            openFileDialog.Filter="Text Files|*.txt";
            openFileDialog.InitialDirectory=Application.StartupPath;
            openFileDialog.DefaultExt="txt";
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                for(int i=0;i<hand.Length;i++)
                {
                    hand[i]=Card.NoCard;
                    cardBoxes[i].Image=null;
                    keepBoxes[i].Checked=false;
                }
                if(!deck.LoadHand(openFileDialog.FileName,hand))
                {
                    MessageBox.Show("Error loading hand file.");
                    return;
                }
                UpdateHandPictureBoxes();
                deckFormInstance?.UpdateDeck();
            }
        }
        private void btnSave_Click(object sender,EventArgs e)
        {
            saveFileDialog.Filter="Text Files|*.txt";
            saveFileDialog.InitialDirectory=Application.StartupPath;
            saveFileDialog.DefaultExt="txt";
            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
                if(!deck.SaveHand(saveFileDialog.FileName,hand))
                {
                    MessageBox.Show("Error saving hand.");
                }
            }
        }
        private void checkBox3_CheckedChanged(object sender,EventArgs e)
        {
        }
        private void UpdateHandPictureBoxes()
        {
            picCard1.Image=hand[0].CardImage;
            picCard2.Image=hand[1].CardImage;
            picCard3.Image=hand[2].CardImage;
            picCard4.Image=hand[3].CardImage;
            picCard5.Image=hand[4].CardImage;
        }
        private void btnShowDeck_Click(object sender,EventArgs e)
        {
            if(deckFormInstance==null||deckFormInstance.IsDisposed)
            {
                deckFormInstance=new DeckForm(deck);
                deckFormInstance.FormClosed+=(s,ev)=>deckFormInstance=null;
                deckFormInstance.Show(this);
            }
            else if(!deckFormInstance.Visible)
            {
                deckFormInstance.Show(this);
            }
            else
            {
                deckFormInstance.BringToFront();
            }
        }
    }
}