

using Android.Content;

using AndroidX.Core.Content;

using Budget.Droid.Dependecies;
using Budget.Interfaces;

using System.Threading.Tasks;

using Xamarin.Forms;

[assembly: Dependency(typeof(Share))]
namespace Budget.Droid.Dependecies {
    internal class Share : IShare {
        public Task Show(string title, string messge, string filePath) {

            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            var documentUri = FileProvider.GetUriForFile(Android.App.Application.Context,
                "com.companyname.budget.provider",
                new Java.IO.File(filePath));

            intent.PutExtra(Intent.ExtraStream, documentUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, messge);

            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);
            chooserIntent.SetFlags(ActivityFlags.NewTask);

            Android.App.Application.Context.StartActivity(chooserIntent);

            return Task.FromResult(true);


        }
    }
}