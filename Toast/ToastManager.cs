using Microsoft.Toolkit.Uwp.Notifications;
using System.Diagnostics;
using System.IO;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Shikashi.Toast
{
    class ToastManager
    {
        private static string shikashiImagePath = "file:///" + Path.GetFullPath("shikashi.png");

        public static void CreateToast(string title, string text)
        {
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            stringElements[0].AppendChild(toastXml.CreateTextNode(title));
            stringElements[1].AppendChild(toastXml.CreateTextNode(text));

            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = shikashiImagePath;
            
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier(GlobalFunctions.APP_ID).Show(toast);
        }

        public static void CreateToastForUpload(string title, string text, string url, string imagePath)
        {
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = title,
                            HintMaxLines = 1
                        },

                        new AdaptiveText()
                        {
                            Text = text
                        },

                        new AdaptiveText()
                        {
                            Text = url
                        },

                        new AdaptiveText()
                        {
                            Text = url
                        }
                    },
                    HeroImage = new ToastGenericHeroImage()
                    {
                        Source = $"file:///{imagePath}"
                    },
                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = shikashiImagePath,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };

            ToastContent toastContent = new ToastContent()
            {
                Visual = visual
            };

            XmlDocument toastContentXml = new XmlDocument();
            toastContentXml.LoadXml(toastContent.GetContent());
            ToastNotification toast = new ToastNotification(toastContentXml); // zzz
            toast.Activated += (e, args) => { Process.Start(url); };

            ToastNotificationManager.CreateToastNotifier(GlobalFunctions.APP_ID).Show(toast);
        }
    }
}
