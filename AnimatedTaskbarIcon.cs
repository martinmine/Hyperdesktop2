using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Shikashi
{
    class AnimatedTaskbarIcon
    {
        private Thread animationThread;
        private bool animateIcon;
        private Dispatcher dispatcher;
        private ImageSource imageSource;
        private Dictionary<string, ImageSource> imageCache;

        public AnimatedTaskbarIcon(Dispatcher dispatcher, ImageSource imageSource)
        {
            this.dispatcher = dispatcher;
            this.imageSource = imageSource;
            this.imageCache = new Dictionary<string,ImageSource>();
        }

        internal void StartAnimation()
        {
            animateIcon = false;

            if (animationThread != null && animationThread.IsAlive)
                animationThread.Abort();

            animateIcon = true;
            animationThread = new Thread(() =>
            {
                try
                {
                    int iconNum = 0;

                    while (animateIcon)
                    {
                        iconNum = (iconNum++ % 19) + 1;
                        SetTaskbarIcon("pack://application:,,,/Shikashi;component/Icons/" + iconNum + ".ico");

                        Thread.Sleep(260);
                    }
                }
                catch (ThreadInterruptedException) { }
            });

            animationThread.Start();
        }

        internal void StopAnimation()
        {
            new Thread(() =>
            {
                animateIcon = false;
                animationThread.Join();
                SetTaskbarIcon("pack://application:,,,/Shikashi;component/icon.ico");
            }).Start();
        }
        private void SetTaskbarIcon(string imageUri)
        {
            dispatcher.Invoke(() =>
            {
                imageSource = GetImage(imageUri);
            });
        }

        private ImageSource GetImage(string uri)
        {
            ImageSource image;
            if (!imageCache.TryGetValue(uri, out image))
            {
                image = new BitmapImage(new Uri(uri));
                imageCache.Add(uri, image);
            }

            return image;
        }
    }
}
