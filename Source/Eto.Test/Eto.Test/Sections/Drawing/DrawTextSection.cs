using System.Collections.Generic;
using Eto.Forms;
using Eto.Drawing;
using System;

namespace Eto.Test.Sections.Drawing
{
	public class DrawTextSection : Scrollable
	{
		public DrawTextSection()
		{
			var layout = new DynamicLayout();

			layout.AddRow(
				new Label { Text = "Default" }, Default(),
				null
			);

			layout.Add(null);

			Content = layout;
		}

		Control Default()
		{
			var control = new Drawable { Size = new Size(400, 500), BackgroundColor = Colors.Black };
			control.Paint += (sender, e) => DrawFrame(e.Graphics);
			return control;
		}

		class DrawInfo
		{
			public Font Font { get; set; }
			string text;
			public string Text
			{
				get
				{
					if (string.IsNullOrEmpty(text) &&
						Font != null)
					{
						var styles = new List<string>();
						if (Font.Bold) styles.Add("Bold");
						if (Font.Italic) styles.Add("Italic");
						if (Font.Underline) styles.Add("Underline");
						var style = string.Join(" & ", styles.ToArray());
						text = string.Format("{0} {1} {2}pt", Font.Family.Name, style, Font.Size);
					}
					return text;
				}
				set { text = value; }
			}
		}

		IEnumerable<DrawInfo> GetDrawInfo()
		{
			yield return new DrawInfo { Font = new Font(SystemFont.Default, generator: Platform), Text = "System Font & Size" };
			yield return new DrawInfo { Font = new Font(SystemFont.Default, 20, generator: Platform), Text = "System Font, 20pt" };

			yield return new DrawInfo { Font = Fonts.Sans(12, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Serif(12, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Monospace(12, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Cursive(12, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Fantasy(12, generator: Platform)};

			yield return new DrawInfo { Font = Fonts.Sans(12, FontStyle.Bold, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Serif(12, FontStyle.Bold, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Monospace(12, FontStyle.Bold, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Cursive(12, FontStyle.Bold, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Fantasy(12, FontStyle.Bold, generator: Platform)};

			yield return new DrawInfo { Font = Fonts.Sans(12, FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Serif(12, FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Monospace(12, FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Cursive(12, FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Fantasy(12, FontStyle.Italic, generator: Platform)};

			yield return new DrawInfo { Font = Fonts.Sans(12, FontStyle.Bold | FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Serif(12, FontStyle.Bold | FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Monospace(12, FontStyle.Bold | FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Cursive(12, FontStyle.Bold | FontStyle.Italic, generator: Platform)};
			yield return new DrawInfo { Font = Fonts.Fantasy(12, FontStyle.Bold | FontStyle.Italic, generator: Platform)};
		}

		internal void DrawFrame(Graphics g)
		{
			float y = 0;
			foreach (var info in GetDrawInfo())
			{
				var size = g.MeasureString(info.Font, info.Text);
				g.DrawText(info.Font, Colors.White, 10, y, info.Text);
				y += size.Height;
			}
		}
	}
}
