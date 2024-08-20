using System.Threading.Tasks;
using System.Xml;

namespace RxConverteriOS
{
    public partial class MainPage : ContentPage
    {
        EyeRx initialRx;
        EyeRx result;
        public MainPage()
        {
            InitializeComponent();
            initialRx = new EyeRx();
            result = new EyeRx();
        }
        private async void OnConvertClicked(object sender, EventArgs e)
        {
            double rSphereInput;
            double rCylInput;
            int rAxisInput;
            double lSphereInput;
            double lCylInput;
            int lAxisInput;

            if (RightSphere.Text == String.Empty)
            {
                await DisplayAlert("Error", "Right Sphere Required.", "OK");
                return;
            }
            else if(!IsDecimalFormat(RightSphere.Text)) 
            {
                await DisplayAlert("Error", "Right Sphere entered invalid.", "OK");
                return;
            }
            else
            {
                rSphereInput = double.Parse(RightSphere.Text);
            }

            if (RightCyl.Text == String.Empty)
            {
                await DisplayAlert("Error", "Right Cyl Required. (Enter 0 if No CYL)", "OK");
                return;
            }
            else if (!IsDecimalFormat(RightCyl.Text))
            {
                await DisplayAlert("Error", "Right Cyl entered invalid.", "OK");
                return;
            }
            else { rCylInput = double.Parse(RightCyl.Text); }

            if (RightAxis.Text == String.Empty)
            {
                await DisplayAlert("Error", "Right Axis Required. (Enter 0 if No Axis)", "OK");
                return;
            }
            else if(!IsIntFormat(RightAxis.Text))
            {
                await DisplayAlert("Error", "Right Axis entered invalid.", "OK");
                return;
            }
            else { rAxisInput = int.Parse(RightAxis.Text); }

            if (LeftSphere.Text == String.Empty)
            {
                await DisplayAlert("Error", "Left Sphere Required.", "OK");
                return;
            }
            else if (!IsDecimalFormat(LeftSphere.Text))
            {
                await DisplayAlert("Error", "Left Sphere entered invalid.", "OK");
                return;
            }
            else
            {
                lSphereInput = double.Parse(LeftSphere.Text);
            }

            if (LeftCyl.Text == String.Empty)
            {
                await DisplayAlert("Error", "Left Cyl Required. (Enter 0 if No CYL)", "OK");
                return;
            }
            else if (!IsDecimalFormat(LeftCyl.Text))
            {
                await DisplayAlert("Error", "Left Cyl entered invalid.", "OK");
                return;
            }
            else { lCylInput = double.Parse(LeftCyl.Text); }


            if (LeftAxis.Text == String.Empty)
            {
                await DisplayAlert("Error", "Left Axis Required. (Enter 0 if No Axis)", "OK");
                return;
            }
            else if (!IsIntFormat(LeftAxis.Text))
            {
                await DisplayAlert("Error", "Left Axis entered invalid.", "OK");
                return;
            }
            else
            {
                lAxisInput = int.Parse(LeftAxis.Text);
            }

            initialRx = new EyeRx(rSphereInput, rCylInput, rAxisInput, lSphereInput, lCylInput, lAxisInput);
            result = ConvertCylinderNotation(initialRx);
            ResultSphereR.Text = result.rightSphere.ToString("N02");
            ResultCylR.Text = result.rightCyl.ToString("N02");
            ResultAxisR.Text = result.rightAxis.ToString("D3");
            ResultSphereL.Text = result.leftSphere.ToString("N02");
            ResultCylL.Text = result.leftCyl.ToString("N02");
            ResultAxisL.Text = result.leftAxis.ToString("D3");
        }
        EyeRx ConvertCylinderNotation(EyeRx rx)
        {
            double rSphere;
            double rCyl;
            int rAxis;
            double lSphere;
            double lCyl;
            int lAxis;
            
            rSphere = rx.rightSphere + rx.rightCyl;
            if (rx.rightCyl == 0)
            {
                rCyl = 0;
            }
            else
            {
                rCyl = -1 * rx.rightCyl;
            }
            rAxis = (rx.rightAxis + 90) % 180;
            if (rAxis == 0)
            {
                rAxis = 180;
            }
            lSphere = rx.leftSphere + rx.leftCyl;

            if (rx.leftCyl == 0)
            {
                lCyl = 0;
            }
            else
            {
                lCyl = -1 * rx.leftCyl;
            }
            lAxis = (rx.leftAxis + 90) % 180;
            if (lAxis == 0)
            {
                lAxis = 180;
            }
            return new EyeRx(rSphere, rCyl, rAxis, lSphere, lCyl, lAxis);
        }
        bool IsDecimalFormat(string i)
        {
            Decimal d;
            try
            {
                return Decimal.TryParse(i, out d);
            }
            catch (Exception e) 
            {
                System.Console.WriteLine(e.Message);
                return false;
            }
        }
        bool IsIntFormat(string s)
        {
            int i;
            try
            {
                return int.TryParse(s, out i);
            }catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }

        }
        private void OnClearClicked(Object sender, EventArgs e)
        {
            RightSphere.Text = string.Empty;
            RightCyl.Text = string.Empty;
            RightAxis.Text = string.Empty;
            LeftSphere.Text = string.Empty;
            LeftCyl.Text = string.Empty;
            LeftAxis.Text = string.Empty;
            ResultSphereR.Text = string.Empty;
            ResultCylR.Text = string.Empty;
            ResultAxisR.Text = string.Empty;
            ResultSphereL.Text = string.Empty;
            ResultCylL.Text = string.Empty;
            ResultAxisL.Text = string.Empty;
        }
    }
}
