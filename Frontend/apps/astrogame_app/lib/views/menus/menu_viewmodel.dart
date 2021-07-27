import 'package:astrogame_app/providers/image_provider.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

import 'menu_entry.dart';

@injectable
class MenuViewModel extends FutureViewModel {
  NavigationWrapper _navigationService;

  AssetImageProvider _assetImageProvider;
  PlayerProvider _playerProvider;

  String get playerName => _playerProvider.getPlayer()?.username ?? '';

  MenuViewModel(
    this._navigationService,
    this._playerProvider,
    this._assetImageProvider,
  );

  MenuEntry? _selectedItem;
  MenuEntry? get selectedItem => _selectedItem;
  set selectedItem(MenuEntry? val) {
    _selectedItem = val;
    notifyListeners();
  }

  ImageProvider _speciesImage =
      AssetImage('assets/images/species/Alien_AI_red.png');
  ImageProvider get speciesImage => _speciesImage;
  set speciesImage(ImageProvider val) {
    _speciesImage = val;
    notifyListeners();
  }

  Future navigate(MenuEntry item) async {
    // If already on this page, do nothing
    if (selectedItem == item) {
      return;
    }

    _navigationService.navigateSubTo(item.route);
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    speciesImage = await getSpeciesImageAsync();
  }

  Future<ImageProvider> getSpeciesImageAsync() async {
    var player = _playerProvider.getPlayer();

    if (player == null) {
      // TODO: return generic image
      return AssetImage('');
    }

    var assetName = player.playerSpecies!.species.assetName;

    return await _assetImageProvider.get(assetName, ImageScope.species);
  }
}
