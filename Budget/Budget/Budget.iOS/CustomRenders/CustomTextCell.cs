using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Budget.iOS.CustomRenders {
    public class CustomTextCell : TextCellRenderer {

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {

            var cell = base.GetCell(item, reusableCell, tv);

            switch (item.StyleId) {
                case "none":
                    cell.Accessory = UITableViewCellAccessory.None;
                    break;
                case "checkmark":
                    cell.Accessory = UITableViewCellAccessory.Checkmark;
                    break;
                case "detail-button":
                    cell.Accessory = UITableViewCellAccessory.DetailButton;
                    break;
                case "disclosure":
                default:
                    cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
                    break;
            }

            return cell;
        }
    }
}