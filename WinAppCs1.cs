using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Forms;




// Assign the Mandelbrot bitmap to the PictureBox
Bitmap mandelplaatje = new Bitmap(500, 500);
Form scherm = new Form();
scherm.Text = "mandel";
scherm.ClientSize = new Size(1000, 900);

//soundplayer om het volkslied af te spelen
System.Media.SoundPlayer soundPlayer = new System.Media.SoundPlayer();
Label playAudioButton = new Label();
playAudioButton.Text = "USSR";
playAudioButton.Location = new Point(40, 90);
scherm.Controls.Add(playAudioButton);

//GUI interface met de globale approach zonder klassen
Label labmiddenX = new Label(); labmiddenX.Location = new Point(40, 20); labmiddenX.Size = new Size(70, 20);
Label labmiddenY = new Label(); labmiddenY.Location = new Point(40, 60); labmiddenY.Size = new Size(70, 20);
Label labschaal = new Label(); labschaal.Location = new Point(360, 20); labschaal.Size = new Size(50, 20);
Label labmaxaantal = new Label(); labmaxaantal.Location = new Point(360, 60); labmaxaantal.Size = new Size(60, 20);


TextBox TinvoerX = new TextBox(); TinvoerX.Location = new Point(140, 20); TinvoerX.Size = new Size(120, 20);
TextBox TinvoerY = new TextBox(); TinvoerY.Location = new Point(140, 60); TinvoerY.Size = new Size(120, 20);
TextBox Tinvoerschaal = new TextBox(); Tinvoerschaal.Location = new Point(440, 20); Tinvoerschaal.Size = new Size(120, 20);
TextBox Tmaxaantal = new TextBox(); Tmaxaantal.Location = new Point(440, 60); Tmaxaantal.Size = new Size(120, 20);

Button Bberekenalles = new Button(); Bberekenalles.Location = new Point(855, 20); Bberekenalles.Size = new Size(100, 100);

Button Preset1 = new Button(); Preset1.Location = new Point(645, 20); Preset1.Size = new Size(100, 50);
Button Preset2 = new Button(); Preset2.Location = new Point(750, 20); Preset2.Size = new Size(100, 50);
Button Preset3 = new Button(); Preset3.Location = new Point(750, 70); Preset3.Size = new Size(100, 50);

Button standaard = new Button(); standaard.Location = new Point(645, 70); standaard.Size = new Size(100, 50);
Button zoom = new Button(); zoom.Location = new Point(265, 20); zoom.Size = new Size(70, 30);
Button uitzoom = new Button(); uitzoom.Location = new Point(265, 50); uitzoom.Size = new Size(70, 30);
Button randomKleur = new Button(); randomKleur.Location = new Point(265, 80); randomKleur.Size = new Size(70, 35);
Button SavedPreset = new Button(); SavedPreset.Location = new Point(700, 440); SavedPreset.Size = new Size(200, 200);


//trackbar maken die r waarde van rgb van het scherm regelt
TrackBar verschuifbaar = new TrackBar(); scherm.Controls.Add(verschuifbaar);
verschuifbaar.Location = new Point(550, 120);
verschuifbaar.Size = new Size(0, 525);
verschuifbaar.Minimum = 10;
verschuifbaar.Maximum = 254;
verschuifbaar.Orientation = Orientation.Vertical;

//trackbar maken die g waarde van rgb van het scherm regelt
TrackBar verschuifbaar2 = new TrackBar(); scherm.Controls.Add(verschuifbaar2);
verschuifbaar2.Location = new Point(600, 120);
verschuifbaar2.Size = new Size(0, 525);
verschuifbaar2.Minimum = 10;
verschuifbaar2.Maximum = 254;
verschuifbaar2.Orientation = Orientation.Vertical;

//trackbar maken die b waarde van rgb van het scherm regelt
TrackBar verschuifbaar3 = new TrackBar(); scherm.Controls.Add(verschuifbaar3);
verschuifbaar3.Location = new Point(650, 120);
verschuifbaar3.Size = new Size(0, 525);
verschuifbaar3.Minimum = 10;
verschuifbaar3.Maximum = 254;
verschuifbaar3.Orientation = Orientation.Vertical;

Label schermsliders = new Label(); scherm.Controls.Add(schermsliders); schermsliders.Location = new Point(700, 120); schermsliders.Size = new Size(300, 30); schermsliders.Text = "Sliders voor de RBG waarden\n van het scherm zelf  ";

//trackbars die de kleuren van de mandelbrot bepalen
TrackBar trackbar = new TrackBar();//rood waarde
scherm.Controls.Add(trackbar);
trackbar.Location = new Point(700, 280);
trackbar.Size = new Size(300, 30);
trackbar.Minimum = 1;
trackbar.Maximum = 20;
trackbar.BackColor = Color.Red;
trackbar.Orientation = Orientation.Horizontal;

TrackBar trackbar2 = new TrackBar();//groen waarde
scherm.Controls.Add(trackbar2);
trackbar2.Location = new Point(700, 320);
trackbar2.Size = new Size(300, 30);
trackbar2.Minimum = 1;
trackbar2.Maximum = 20;
trackbar2.BackColor = Color.Green;
trackbar2.Orientation = Orientation.Horizontal;

TrackBar trackbar3 = new TrackBar();//blauw waarde
scherm.Controls.Add(trackbar3);
trackbar3.Location = new Point(700, 360);
trackbar3.Size = new Size(300, 30);
trackbar3.Minimum = 1;
trackbar3.Maximum = 20;
trackbar3.BackColor = Color.Blue;
trackbar3.Orientation = Orientation.Horizontal;

TrackBar trackbar4 = new TrackBar();// helderheid van de mandelbrot door middel van een constante k waarde
scherm.Controls.Add(trackbar4);
trackbar4.Location = new Point(700, 400);
trackbar4.Size = new Size(300, 30);
trackbar4.Minimum = 1;
trackbar4.Maximum = 12;
trackbar4.BackColor = Color.Gray;
trackbar4.Orientation = Orientation.Horizontal;
Label mandelsliders = new Label(); scherm.Controls.Add(mandelsliders); mandelsliders.Location = new Point(800, 240); mandelsliders.Size = new Size(300, 30);mandelsliders.Text="Sliders voor de RBG waarden\n van de mandelbrot  ";

//moeten allemaal toegevoegd worden aan het scherm
scherm.Controls.Add(labmiddenX); labmiddenX.Text = "middenX:";
scherm.Controls.Add(labmiddenY); labmiddenY.Text = "middenY:";
scherm.Controls.Add(labschaal); labschaal.Text = "schaal:";
scherm.Controls.Add(labmaxaantal); labmaxaantal.Text = "herhaling:";
scherm.Controls.Add(TinvoerX); TinvoerX.Text = 0.ToString();
scherm.Controls.Add(TinvoerY); TinvoerY.Text = 0.ToString();
scherm.Controls.Add(Tinvoerschaal); Tinvoerschaal.Text = 0.01.ToString();
scherm.Controls.Add(Tmaxaantal); Tmaxaantal.Text = 100.ToString();
scherm.Controls.Add(Bberekenalles); Bberekenalles.Text = "Bereken alles bliep bloop!";
scherm.Controls.Add(SavedPreset); SavedPreset.Text = "press to go to saved location.You can safe by clicking save on the right label";
scherm.Controls.Add(Preset1); Preset1.Text = "preset 1";
scherm.Controls.Add(Preset2); Preset2.Text = "random kleur preset2";
scherm.Controls.Add(Preset3); Preset3.Text = "The Starry night";
scherm.Controls.Add(standaard); standaard.Text = "standaard locatie";
scherm.Controls.Add(zoom); zoom.Text = "zoom in";
scherm.Controls.Add(uitzoom); uitzoom.Text = "zoom uit";
scherm.Controls.Add(randomKleur); randomKleur.Text = "random kleurtje";



//label waar je op kan klikken om je mandelbrot te saven als tijdelijke preset
Label save = new Label(); save.Location = new Point(900, 540); save.Size = new Size(200, 200); save.Text = "Save here!"; scherm.Controls.Add(save);

//dit label wordt gekoppeld worden aan een bitmap en laat de mandelbrotset zien. 
Label mandelbrotset = new Label();
scherm.Controls.Add(mandelbrotset);
mandelbrotset.Location = new Point(40, 120);
mandelbrotset.Size = new Size(500, 500);


// dit is de naam van de bitmap die gekoppeld wordt aan een label
// Bitmap mandelplaatje = new Bitmap(500, 500);
mandelbrotset.Image = mandelplaatje;


// globale toestand-variabelen
int maxaantal = 0;
double middenx = 0;
double middeny = 0;
double schaal = 0;

int mandelkleurtje = 1;
int mandelkleurtje2 = 1;
int mandelkleurtje3 = 1;

int k = 12;
trackbar4.Value = k;

int clickCount = 0;
int saver = 0;
bool isAudioPlaying = false;

double presetX = 0;
double presetY = 0;
double presetSchaal = 0;
int presetHerhaling = 0;

int rood, groen, blauw;

//fuctie die het mandelgetal berekend
int mandelbereken(double x, double y)
{
    maxaantal = int.Parse(Tmaxaantal.Text);
    int mandelgetal = 0;
    double a = 0;
    double b = 0;
    while (System.Math.Sqrt(a * a + b * b) <= 2 && mandelgetal <= maxaantal)        //pythagoras van a en b geeft de afstand tussen (0.0) en (a.b)
    {
        double atwee = (a * a - b * b + x);                       //formule a
        double btwee = (2 * a * b + y);                           //formule b
        a = atwee;
        b = btwee;
        mandelgetal++;
    }
    return mandelgetal;
}



void tekenmandel()

{
    try
    {
        int middenX = ((mandelplaatje.Width) / 2); //dus gewoon de helft van de bitmap
        int middenY = (mandelplaatje.Height / 2);

        schaal = double.Parse(Tinvoerschaal.Text);
        double middenx = double.Parse(TinvoerX.Text);
        double middeny = double.Parse(TinvoerY.Text);

        for (int yPixel = 0; yPixel < mandelplaatje.Height; yPixel++)// loopt door alle pixels heen en kleurt de bitmap
        {
            for (int xPixel = 0; xPixel < mandelplaatje.Width; xPixel++)
            {
                double xWaarde = (xPixel - middenX) * schaal + middenx;
                double yWaarde = (middenY - yPixel) * schaal + middeny;

                int mandel = mandelbereken(xWaarde, yWaarde);


                if (mandelbereken(xWaarde, yWaarde) >= maxaantal)// mandelgetal is oneindig dus kleur het zwart
                {
                    mandelplaatje.SetPixel(xPixel, yPixel, Color.Black);
                }
                else
                {
                    mandelplaatje.SetPixel(xPixel, yPixel, Color.FromArgb(
                        Math.Max(0, (int)((k * mandelkleurtje * mandel * Math.Cos(mandel / mandelkleurtje) % 256)))    //rood waarde
                        , Math.Max(0, (int)((k * mandelkleurtje2 * mandel * Math.Cos(mandel / mandelkleurtje2) % 256)))  //groen waarde
                        , Math.Max(0, (int)((k * mandelkleurtje3 * mandel * Math.Cos(mandel / mandelkleurtje3) % 256))))     // blauw waarde
                        );
                }

            }
            mandelbrotset.Invalidate();
        }
    }
    catch (FormatException)
    {
        
        TextBox textBoxWithError = null;

        
        if (!int.TryParse(Tmaxaantal.Text, out _))
        {
            textBoxWithError = Tmaxaantal;
        }
        else if (!double.TryParse(Tinvoerschaal.Text, out _))
        {
            textBoxWithError = Tinvoerschaal;
        }
        else if (!double.TryParse(TinvoerX.Text, out _))
        {
            textBoxWithError = TinvoerX;
        }
        else if (!double.TryParse(TinvoerY.Text, out _))
        {
            textBoxWithError = TinvoerY;
        }

       
        if (textBoxWithError != null)
        {
            textBoxWithError.BackColor = Color.Red;
        }

        DialogResult result = MessageBox.Show("Something went terribly wrong but do not panic. There are atleast some smart people.\n\nModern technology AUTOFIX", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

        if (result == DialogResult.Yes && textBoxWithError != null)
        {
           
            MessageBox.Show($"{textBoxWithError.Name} is not a valid number. But because this programmer is actually smart he will autofix it for you", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            textBoxWithError.BackColor = SystemColors.Window;
            if (textBoxWithError == Tinvoerschaal)
                textBoxWithError.Text = 0.1.ToString();
            else if (textBoxWithError == Tmaxaantal)
                textBoxWithError.Text = 100.ToString();
            else
                textBoxWithError.Text = 0.ToString();
        }
    }


}






void geklikt_op_berekenknop(object sender, EventArgs e)
{
    try
    {
        maxaantal = int.Parse(Tmaxaantal.Text);
        schaal = double.Parse(Tinvoerschaal.Text);
        middenx = double.Parse(TinvoerX.Text);
        middeny = double.Parse(TinvoerY.Text);
        endprocedure();
    }


    catch (FormatException)
    {
        
        TextBox textBoxWithError = null;

      
        if (!int.TryParse(Tmaxaantal.Text, out _))
        {
            textBoxWithError = Tmaxaantal;
        }
        else if (!double.TryParse(Tinvoerschaal.Text, out _))
        {
            textBoxWithError = Tinvoerschaal;
        }
        else if (!double.TryParse(TinvoerX.Text, out _))
        {
            textBoxWithError = TinvoerX;
        }
        else if (!double.TryParse(TinvoerY.Text, out _))
        {
            textBoxWithError = TinvoerY;
        }

       
        if (textBoxWithError != null)
        {
            textBoxWithError.BackColor = Color.Red;
        }

        DialogResult result = MessageBox.Show("Something went terribly wrong but do not panic.There are atleast some smart people.\n\nModern Autofix technology", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

        if (result == DialogResult.Yes && textBoxWithError != null)
        {
            
            MessageBox.Show($"{textBoxWithError.Name} is not a valid number. But the computer is actually smart and fixes it for you", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBoxWithError.BackColor = SystemColors.Window;
            if (textBoxWithError == Tinvoerschaal)
                textBoxWithError.Text = 0.1.ToString();
            else if (textBoxWithError == Tmaxaantal)
                textBoxWithError.Text = 100.ToString();
            else
                textBoxWithError.Text = 0.ToString();
        }
    }


}
void schuifEventScherm(object o, EventArgs ea)
{
    rood = verschuifbaar.Value;
    groen = verschuifbaar2.Value;
    blauw = verschuifbaar3.Value;


    Color veranderbaar = Color.FromArgb((rood) % 255, (groen) % 255, (blauw) % 255);
    scherm.BackColor = veranderbaar;
    scherm.Invalidate();
}
void schuifEventMandel(object o, EventArgs ea)
{
    mandelkleurtje = trackbar.Value;
    mandelkleurtje2 = trackbar2.Value;
    mandelkleurtje3 = trackbar3.Value;
    rood = trackbar.Value*12;
    groen = trackbar2.Value*12;
    blauw = trackbar3.Value*12;
    Color veranderbaar = Color.FromArgb((rood) % 255, (groen) % 255, (blauw) % 255);
    scherm.BackColor = veranderbaar;
    k = trackbar4.Value;
    endprocedure();
}
void geklikt_op_Preset1(object sender, EventArgs e)
{
    Random random = new Random();
    int r = random.Next(20) + 1;
    int b = random.Next(20) + 1;
    int g = random.Next(20) + 1;
    int verzadiging = random.Next(10) + 1;
    middenx = -1.3609835499525063;middeny = 0.07103952765464784;schaal = 2.9802322387695313E-10; maxaantal = 200;
    maxaantal = 400;

    ToTextbox(middenx, middeny, schaal, maxaantal);
    kleur(r, g, b, verzadiging);
    endprocedure();
}
void kleur(int r, int g, int b, int verzadiging)
{

    trackbar.Value = r;
    trackbar2.Value = g;
    trackbar3.Value = b;
    trackbar4.Value = verzadiging;

    mandelkleurtje = trackbar.Value;
    mandelkleurtje2 = trackbar2.Value;
    mandelkleurtje3 = trackbar3.Value;
    k = trackbar4.Value;
    rood = trackbar.Value * 12;
    groen = trackbar2.Value * 12;
    blauw = trackbar3.Value * 12;
    Color veranderbaar = Color.FromArgb((rood) % 255, (groen) % 255, (blauw) % 255);
    scherm.BackColor = veranderbaar;
}
void geklikt_op_Preset2(object sender, EventArgs e)
{
    Random random = new Random();
    int r = random.Next(20) + 1;
    int b = random.Next(20) + 1;
    int g = random.Next(20) + 1;
    int verzadiging = random.Next(10) + 1;
    middenx = -1.8611239719390875; middeny = 0.0014051818847656172; schaal = 2.384185791015625E-09; maxaantal = 100;
    ToTextbox(middenx, middeny, schaal, maxaantal);
    kleur(r, g, b, verzadiging);
    endprocedure();
}
void geklikt_op_Preset3(object sender, EventArgs e)
{
    middenx = -0.835095010609439; middeny = 0.20867584168120173; schaal = 2.2737367544323206E-15; maxaantal = 2500;
    ToTextbox(middenx, middeny, schaal, maxaantal);
    kleur(14, 14, 5, 10);
    endprocedure();
}
void geklikt_op_CustomSave(object sender, EventArgs e)
{
    ToTextbox(presetX, presetY, presetSchaal, presetHerhaling);
    endprocedure();
}
void kliksave(object sender, EventArgs e)
{
    saver++;
    if (saver % 2 == 1)
    {
        presetX = double.Parse(TinvoerX.Text);
        presetY = double.Parse(TinvoerY.Text);
        presetSchaal = double.Parse(Tinvoerschaal.Text);
        presetHerhaling = int.Parse(Tmaxaantal.Text);
        save.Text = "Saved";
    }
    else
    {
        presetX = 0;
        presetY = 0;
        presetSchaal = 0.01;
        presetHerhaling = 100;
        save.Text = "not saved";
    }
}
void ToTextbox(double x, double y, double schaal, int herhaling)
{
    TinvoerX.Text = x.ToString();
    TinvoerY.Text = y.ToString();
    Tinvoerschaal.Text = schaal.ToString();
    Tmaxaantal.Text = herhaling.ToString();
}
void geklikt_op_standaard(object sender, EventArgs e)
{
    middenx = 0; middeny = 0; schaal = 0.01; maxaantal = 100;
    kleur(1, 1, 1, 12);
    ToTextbox(middenx, middeny, schaal, maxaantal);
    endprocedure();
}
void klikscherm(object o, MouseEventArgs ea)
{
    schaal = double.Parse(Tinvoerschaal.Text);
    maxaantal= int.Parse(Tmaxaantal.Text);
    int HelftX = ((mandelplaatje.Width) / 2);
    int HelftY = ((mandelplaatje.Height) / 2);

    if (ea.Button == MouseButtons.Left)
    {
        // Zoom in
        middenx = middenx + ((ea.X - HelftX) * schaal);
        middeny = middeny + ((HelftY - ea.Y) * schaal);
        maxaantal =(int) (maxaantal +10);
        schaal /= 2;
    }
    else if (ea.Button == MouseButtons.Right)
    {
        // Zoom uit
        middenx = middenx + ((ea.X - HelftX) * schaal * 2);
        middeny = middeny + ((HelftY - ea.Y) * schaal * 2);
        maxaantal = (int)(maxaantal - 10);
        schaal *= 2;
    }

    ToTextbox(middenx, middeny, schaal, maxaantal);
    endprocedure();
}
void geklikt_op_zoomknop(object sender, EventArgs e)
{

    schaal = double.Parse(Tinvoerschaal.Text); ;
    Tinvoerschaal.Text = (schaal / 2).ToString();
    endprocedure();
}
void geklikt_op_uitzoomknop(object sender, EventArgs e)
{

    schaal = double.Parse(Tinvoerschaal.Text); ;
    Tinvoerschaal.Text = (schaal * 2).ToString();
    endprocedure();
}
void geklikt_op_kleurtjeknop(object sender, EventArgs e)
{
    Random random = new Random();
    int r = random.Next(20) + 1;
    int b = random.Next(20) + 1;
    int g = random.Next(20) + 1;
    int verzadiging = random.Next(10) + 1;
    kleur(r, g, b, verzadiging);
    endprocedure();
}
void USSR(object o, PaintEventArgs pea)
{
    Graphics gr = pea.Graphics;
    string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "download.png");// hij zit in de bin omdat daar de executable zit vandaar dat we die niet konden verwijderen
    Console.WriteLine("hoort iets te komen");
    Console.WriteLine(imagePath);
    Bitmap bm = new Bitmap(imagePath);

    float opacity = 0.5f;// als dit 0 is dan is het het transparant en heb je er dus niks aan en bij 1 zie je de ondergrond niet meer dus dat wil je ook niet
    ColorMatrix matrix = new ColorMatrix();
    matrix.Matrix33 = opacity;
    ImageAttributes imageAttributes = new ImageAttributes();
    imageAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
    if (o == mandelbrotset)
    {
        gr.DrawImage(bm, new Rectangle(0, 0, mandelbrotset.Width, mandelbrotset.Height),
                     0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel, imageAttributes);
    }
    else if (o == scherm)
    {
        gr.DrawImage(bm, new Rectangle(0, 0, scherm.Width, scherm.Height),
                     0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel, imageAttributes);
    }
}
void endprocedure()
{
    tekenmandel();
    mandelbrotset.Invalidate();
}
void PlayAudioButton_Click(object sender, EventArgs e)
{
    //niet de bonuspunten van dit groepje nee het zijn ONZE bonuspunten.
    clickCount++;
    if (clickCount % 2 != 0)
    {
        mandelbrotset.Paint += USSR;
        scherm.Paint += USSR;
        scherm.Invalidate();


        string audioFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sound", "National Anthem of USSR.wav");

        // Load an audio file into the SoundPlayer
        soundPlayer.SoundLocation = audioFilePath;

        // Assign colors to the BackColor property of each TextBox
        TinvoerX.BackColor = Color.Yellow;
        TinvoerY.BackColor = Color.Yellow;
        Tinvoerschaal.BackColor = Color.Yellow;
        Tmaxaantal.BackColor = Color.Yellow;

        if (System.IO.File.Exists(soundPlayer.SoundLocation))
        {
            // Play the audio
            soundPlayer.Play();
            isAudioPlaying = true;
            scherm.BackColor = Color.Red;
            kleur(20, 6, 1, 10);
            endprocedure();
        }
        else
        {
            MessageBox.Show("Audio file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    else
    {
        // Check if audio is currently playing
        if (isAudioPlaying)
        {
            // Stop the audio
            soundPlayer.Stop();
            isAudioPlaying = false;
            scherm.BackColor = Color.White;
            TinvoerX.BackColor = Color.White;
            TinvoerY.BackColor = Color.White;
            Tinvoerschaal.BackColor = Color.White;
            Tmaxaantal.BackColor = Color.White;
            mandelbrotset.Paint -= USSR;
            scherm.Paint -= USSR;
            scherm.Invalidate();
        }
    }
}



//bijna alle eventhandlers
mandelbrotset.MouseClick += klikscherm;
verschuifbaar.Scroll += schuifEventScherm;
verschuifbaar2.Scroll += schuifEventScherm;
verschuifbaar3.Scroll += schuifEventScherm;
Bberekenalles.Click += geklikt_op_berekenknop;
Preset1.Click += geklikt_op_Preset1;
Preset2.Click += geklikt_op_Preset2;
Preset3.Click += geklikt_op_Preset3;
SavedPreset.Click += geklikt_op_CustomSave;
standaard.Click += geklikt_op_standaard;
zoom.Click += geklikt_op_zoomknop;
uitzoom.Click += geklikt_op_uitzoomknop;
randomKleur.Click += geklikt_op_kleurtjeknop;
save.Click += kliksave;
trackbar.MouseLeave += schuifEventMandel;
trackbar2.MouseLeave += schuifEventMandel;
trackbar3.MouseLeave += schuifEventMandel;
trackbar4.MouseLeave += schuifEventMandel;
playAudioButton.Click += PlayAudioButton_Click;
tekenmandel();
Application.Run(scherm);
