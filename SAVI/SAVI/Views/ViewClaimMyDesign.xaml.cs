using Demo.Pages;
using Rg.Plugins.Popup.Services;
using SAVI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAVI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewClaimMyDesign : ContentPage
    {
        DateTime dteFrom; DateTime dteTo;
        private ViewClaimList MyViewModel
        {
            get { return (ViewClaimList)BindingContext; }
            set { BindingContext = value; }
        }

        int maxPage = 0;

        int count = 0;
        protected override void OnAppearing()
        {
            base.OnAppearing();


      
          
        }
        public ViewClaimMyDesign(DateTime dteFroM, DateTime dteTO, int pageNumber)
        {
            InitializeComponent();

            //   NavigationPage.SetHasNavigationBar(this, false);



            dteFrom = dteFroM;

            dteTo = dteTO;


            MyViewModel = new ViewClaimList(dteFrom, dteTo);


            MyViewModel.LoadClaimsHistory.Execute(null);

            //pageLoading.CloseMe();

            if (!MyViewModel.stClass.checkstatus)
            {
                var pageMessage = new ShowMessagePopupPage("Unable to get the data");
                PopupNavigation.Instance.PushAsync(pageMessage);
            }


            dataGridHeader.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
            dataGridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });
            dataGridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });
            dataGridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });


            for (int rowIndex = 3; rowIndex < 27; rowIndex++)
            {
                dataGridHeader.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });
            }




            var label = new Label
            {
                Text = "Name",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 0, 0);
            label = new Label
            {
                Text = "Code",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 1, 0);
            label = new Label
            {
                Text = "Description",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 2, 0);
            label = new Label
            {
                Text = "Redemtion Date",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 3, 0);
            label = new Label
            {
                Text = "Invoice Number",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 4, 0);
            label = new Label
            {
                Text = "Brand Name",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 5, 0);

            label = new Label
            {
                Text = "Store Name",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 6, 0);

            label = new Label
            {
                Text = "Store Rep",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 7, 0);

            label = new Label
            {
                Text = "StoreRepMSISDN",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 8, 0);

            label = new Label
            {
                Text = "Imei",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 9, 0);

            label = new Label
            {
                Text = "SubmittedDeviceLocationLatitude",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 10, 0);


            label = new Label
            {
                Text = "SubmittedDeviceLocationLongitude",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 11, 0);


            label = new Label
            {
                Text = "RetailValue",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 12, 0);

            label = new Label
            {
                Text = "Verified",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 13, 0);

            label = new Label
            {
                Text = "Image",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 14, 0);

            label = new Label
            {
                Text = "Disputed",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 15, 0);


            label = new Label
            {
                Text = "Paid",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 16, 0);

            label = new Label
            {
                Text = "VerifiedDisputedDate",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 17, 0);


            label = new Label
            {
                Text = "AutoProcessed",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 18, 0);

            label = new Label
            {
                Text = "DetectCount",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 19, 0);


            label = new Label
            {
                Text = "ContactName",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 20, 0);


            label = new Label
            {
                Text = "ContactSurname",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 20, 0);

            label = new Label
            {
                Text = "ContactMSISDN",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 21, 0);

            label = new Label
            {
                Text = "ContactEmail",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 22, 0);

            label = new Label
            {
                Text = "NoStock",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 23, 0);


            label = new Label
            {
                Text = "Pin",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 24, 0);

            label = new Label
            {
                Text = "InvoiceDateCreated",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 25, 0);

            label = new Label
            {
                Text = "InvoiceDateModified",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            dataGridHeader.Children.Add(label, 26, 0);



            maxPage = 0;

            count = MyViewModel.ClaimsHistory.Count();
            if (count > 0)
                maxPage = (int)(count / 5) + 1;
            else
                maxPage = 0;

            List<int> pagi = new List<int>();
            for (int p = 1; p <= maxPage; p++)
            {
                pagi.Add(p);
            }

            Pageinator.ItemsSource = pagi;




            refreshgrid(pageNumber);



        }




        async void refreshgrid(int pageNumber)
        {

            //dataGrid.Children.Clear();

            //var childGrid = dataGrid.Children.ToList();
            //foreach (var row in childGrid.Where(r => Grid.GetRow(r)==0 ))
            //{
            //    dataGrid.Children.Remove(row);
            //}
            //foreach (var row in childGrid.Where(r => Grid.GetRow(r) == 1))
            //{
            //    dataGrid.Children.Remove(row);
            //}
            //foreach (var row in childGrid.Where(r => Grid.GetRow(r) == 2))
            //{
            //    dataGrid.Children.Remove(row);
            //}
            //foreach (var row in childGrid.Where(r => Grid.GetRow(r) == 3))
            //{
            //    dataGrid.Children.Remove(row);
            //}
            //foreach (var row in childGrid.Where(r => Grid.GetRow(r) == 4))
            //{
            //    dataGrid.Children.Remove(row);
            //}
            //int rowsNumber = 0;
            //foreach (var child in dataGrid.Children.ToArray())
            //{
            //    rowsNumber = (int)child.GetValue(Grid.RowProperty);

            //    dataGrid.Children.Remove(child);

            //}

            //for (int r = 0; r < rowsNumber - 1; r++)
            //{

            //    dataGrid.RowDefinitions.RemoveAt(r);

            //}


            //if (rowsNumber==4)
            //{
            //    dataGrid.RowDefinitions.RemoveAt(0);
            //    dataGrid.RowDefinitions.RemoveAt(1);
            //    dataGrid.RowDefinitions.RemoveAt(2);
            //    //dataGrid.RowDefinitions.RemoveAt(3);
            //    //dataGrid.RowDefinitions.RemoveAt(4);
            //}

            //foreach (var child in dataGrid.Children.ToArray())
            //{
            //     rowsNumber = (int)child.GetValue(Grid.RowProperty);
            ////    dataGrid.RowDefinitions.RemoveAt(childRow);
            //}
            // if (rowsNumber>0)
            //    for (int r = rowsNumber-1; r >= 0; r--)
            //{

            //    dataGrid.RowDefinitions.RemoveAt(r); 

            //}

           // if (dataStackView.Children.Count() > 0)
          //  {
              
               
           //     await Navigation.PushAsync(new ViewClaim(dteFrom, dteTo, pageNumber));
           //     await Navigation.PopAsync();
           // }
           // else
            {
                //if (dataStackView.Children.Count() > 0)
                //{
                //    // dataStackView.Children.RemoveAt(0);
                //   // await Navigation.PopAsync();
                //    await Navigation.PushAsync(new ViewClaim(dteFrom, dteTo, pageNumber));
                //    return;
                //}
                Grid dataGrid = new Grid();

                dataGrid.BackgroundColor = Color.White;
                dataStackView.Children.Add(dataGrid);


                //dataGrid content

                dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });
                dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });
                dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200, GridUnitType.Absolute) });
                for (int colIndex = 3; colIndex < 27; colIndex++)
                {
                    dataGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });
                }


                if (count > 0)

                {
                    int resultcount = 0;
                    if (count < pageNumber * 5) resultcount = count; else resultcount = pageNumber * 5;
                    for (int rowIndex = (pageNumber - 1) * 5; rowIndex < resultcount; rowIndex++)
                    {
                        dataGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60, GridUnitType.Absolute) });
                        var label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].PromotionName,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 0, rowIndex);
                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].ProductCode,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 1, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].ProductDescription,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 2, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].RedemtionDate,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 3, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].InvoiceNumber,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 4, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].BrandName,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 5, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].StoreName,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center
                        };
                        dataGrid.Children.Add(label1, 6, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].StoreRep,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 7, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].StoreRepMSISDN,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 8, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].Imei,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 9, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].SubmittedDeviceLocationLatitude,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 10, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].SubmittedDeviceLocationLongitude,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 11, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].RetailValue,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 12, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].Verified,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 13, rowIndex);

                        label1 = new Label
                        {
                            Text = "View",
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };




                        label1.GestureRecognizers.Add(new TapGestureRecognizer()
                        {
                            Command = _viewImageCommand,
                            CommandParameter = MyViewModel.ClaimsHistory[rowIndex]
                        });
                        label1.TextColor = Color.Red;
                        //span.TextDecorations = TextDecorations.Underline;
                        if (MyViewModel.ClaimsHistory[rowIndex].HasImage == "false") { label1.IsEnabled = false; label1.TextColor = Color.LightGray; label1.Text = "No Image"; label1.TextDecorations = TextDecorations.Strikethrough; }
                        dataGrid.Children.Add(label1, 14, rowIndex);//image

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].Disputed,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 15, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].Paid,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 16, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].VerifiedDisputedDate,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 17, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].AutoProcessed,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 19, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].DetectCount,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 20, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].ContactName,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 21, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].ContactSurname,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 22, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].ContactMSISDN,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 23, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].ContactEmail,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 24, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].NoStock,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 25, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].Pin,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 26, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].InvoiceDateCreated,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 27, rowIndex);

                        label1 = new Label
                        {
                            Text = MyViewModel.ClaimsHistory[rowIndex].InvoiceDateModified,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        dataGrid.Children.Add(label1, 28, rowIndex);
                    }
                }
            }

        }

        private ICommand _viewImageCommand = new Command<ViewClaimViewModel>(async (ClaimHistoryRow) =>
        {
            var inv=ClaimHistoryRow.InvoiceNumber;
            var strid = ClaimHistoryRow.StoreID;
            if (string.IsNullOrWhiteSpace(ClaimHistoryRow.InvoiceNumber) || string.IsNullOrWhiteSpace(ClaimHistoryRow.StoreID)) return;
           string strImage = App.SoapService.GetInvoiceImage(ClaimHistoryRow.InvoiceNumber, ClaimHistoryRow.StoreID).GetInvoiceImageResult;

           // Application.Current.MainPage = new ImageClaim(strImage);

            //Task.Run(async ()=>  await Navigation.PushAsync(new ImageClaim(strImage)));
             var pageMessage = new ImageOfClaim(strImage);
             await PopupNavigation.Instance.PushAsync(pageMessage);
        });

        private  void Pageinator_SelectedIndexChanged(object sender, EventArgs e)
        {

          

           
            refreshgrid((int)Pageinator.SelectedItem);


            //await Navigation.PushAsync(new ViewClaimMyDesign(dteFrom, dteTo, (int)Pageinator.SelectedItem));
           // await Navigation.PopAsync();
        }
    }
   
}