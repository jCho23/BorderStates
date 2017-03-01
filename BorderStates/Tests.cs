using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using System.Threading;

namespace BorderStates
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
			app.Screenshot("App Launched");
		}

		[Test]
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void FirstTest()
		{
			app.Tap(x => x.Class("android.widget.TextView").Index(3));
			app.Screenshot("We tapped on 'Products'");

			app.Tap(x => x.Marked("tv_category_name").Index(1));
			app.Screenshot("We tapped on 'Boxes and Enclosures'");

			app.Tap(x => x.Marked("tv_category_name").Index(1));
			app.Screenshot("We tapped on 'Boxes'");


			app.Tap(x => x.Marked("tv_category_name").Index(2));
			app.Screenshot("We tapped on our box");

			app.Tap(x => x.Marked("tv_category_name").Index(3));
			app.Screenshot("We tapped on our specific box");

			app.Back();
			app.Screenshot("We tapped the Back Button");

			app.Tap(x => x.Marked("tv_category_name").Index(3));
			app.Screenshot("We tapped on a differnt box");

			app.Back();
			app.Screenshot("We tapped the Back Button");


			app.Tap(x => x.Marked("tv_category_name").Index(3));
			app.Screenshot("We tapped on another box");

			app.Back();
			app.Screenshot("We tapped the Back Button");


			app.Back();
			app.Screenshot("We tapped the Back Button");


			app.Tap(x => x.Marked("tv_category_name").Index(1));

			app.Back();
			app.Screenshot("We tapped the Back Button");


			app.Tap(x => x.Class("android.widget.ImageButton"));
			app.Screenshot("We tapped the Hamburger Icon");

			app.Tap(x => x.Marked("linear_nav_locations"));
			Thread.Sleep(30000);
			app.Screenshot("We tapped on 'Locations'");
		}



	}
}
