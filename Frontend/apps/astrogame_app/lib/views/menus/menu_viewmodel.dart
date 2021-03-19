import 'package:stacked/stacked.dart';
import 'package:stacked_services/stacked_services.dart';

import 'menu_entry.dart';

class MenuViewModel extends BaseViewModel {
  NavigationService _navigationService;

  MenuEntry _selectedItem;
  MenuEntry get selectedItem => _selectedItem;
  set selectedItem(MenuEntry val) {
    _selectedItem = val;
    notifyListeners();
  }

  MenuViewModel(this._navigationService);

  Future navigate(MenuEntry item) async {
    // If already on this page, do nothing
    if (selectedItem == item) {
      return;
    }

    _navigationService.navigateTo(item.route);
  }
}
