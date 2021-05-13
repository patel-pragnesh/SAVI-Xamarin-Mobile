using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo.Pages
{
    public partial class ShowMessagePopupPage : PopupPage
  {
    public ShowMessagePopupPage(string message)
    {
      InitializeComponent();
            CloseWhenBackgroundIsClicked = false;
            MessageLabel.Text = message;
    }
        protected override bool OnBackButtonPressed()
        {
            return true; // Disable back button
        }
        protected override void OnAppearingAnimationBegin()
    {
      base.OnAppearingAnimationBegin();
      //FrameContainer.HeightRequest = -1;
      FrameContainer.HeightRequest = Application.Current.MainPage.Height - (Application.Current.MainPage.Height * 0.6);

      FrameContainer.WidthRequest = Application.Current.MainPage.Width - (Application.Current.MainPage.Width * 0.2);

      if (!IsAnimationEnabled)
      {
        CloseImage.Rotation = 0;
        CloseImage.Scale = 1;
        CloseImage.Opacity = 1;

        //LoginButton.Scale = 1;
        //LoginButton.Opacity = 1;

        //UsernameEntry.TranslationX = PasswordEntry.TranslationX = 0;
        //UsernameEntry.Opacity = PasswordEntry.Opacity = 1;

        return;
      }

      CloseImage.Rotation = 30;
      CloseImage.Scale = 0.3;
      CloseImage.Opacity = 0;


    }

    protected override async Task OnAppearingAnimationEndAsync()
    {
      if (!IsAnimationEnabled)
        return;

   //   var translateLength = 400u;

    //  await Task.WhenAll(
          //UsernameEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
          //UsernameEntry.FadeTo(1),
          //(new Func<Task>(async () =>
          //{
          //  await Task.Delay(200);
          //  await Task.WhenAll(
          //            PasswordEntry.TranslateTo(0, 0, easing: Easing.SpringOut, length: translateLength),
          //            PasswordEntry.FadeTo(1));

          //}))()
    //      );

      await Task.WhenAll(
          CloseImage.FadeTo(1),
          CloseImage.ScaleTo(1, easing: Easing.SpringOut),
          CloseImage.RotateTo(0));
      //LoginButton.ScaleTo(1),
      //LoginButton.FadeTo(1));
    }

    protected override async Task OnDisappearingAnimationBeginAsync()
    {
      if (!IsAnimationEnabled)
        return;

      var taskSource = new TaskCompletionSource<bool>();

      var currentHeight = FrameContainer.Height;

    //  await Task.WhenAll(
      //UsernameEntry.FadeTo(0),
      //PasswordEntry.FadeTo(0),
      //LoginButton.FadeTo(0));
    //  );
      FrameContainer.Animate("HideAnimation", d =>
      {
        FrameContainer.HeightRequest = d;
      },
      start: currentHeight,
      end: 170,
      finished: async (d, b) =>
      {
        await Task.Delay(300);
        taskSource.TrySetResult(true);
      });

      await taskSource.Task;
    }


    private void OnCloseButtonTapped(object sender, EventArgs e)
    {
      CloseAllPopup();
    }

    protected override bool OnBackgroundClicked()
    {
      CloseAllPopup();

      return false;
    }

    private async void CloseAllPopup()
    {
      await PopupNavigation.Instance.PopAsync();
    }

  }
}
