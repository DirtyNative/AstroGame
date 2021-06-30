import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

import 'menu_entry.dart';

@injectable
class MenuViewModel extends BaseViewModel {
  NavigationWrapper _navigationService;

  SpeciesImageProvider _speciesImageProvider;
  PlayerProvider _playerProvider;

  MenuEntry _selectedItem;
  MenuEntry get selectedItem => _selectedItem;
  set selectedItem(MenuEntry val) {
    _selectedItem = val;
    notifyListeners();
  }

  String get playerName => _playerProvider.getPlayer().username;

  MenuViewModel(
    this._navigationService,
    this._playerProvider,
    this._speciesImageProvider,
  );

  Future navigate(MenuEntry item) async {
    // If already on this page, do nothing
    if (selectedItem == item) {
      return;
    }

    _navigationService.navigateSubTo(item.route);
    notifyListeners();
  }

  Future<ImageProvider> getSpeciesImageAsync() async {
    var assetName = _playerProvider.getPlayer().playerSpecies.species.assetName;

    return await _speciesImageProvider.get(assetName);
  }
}
