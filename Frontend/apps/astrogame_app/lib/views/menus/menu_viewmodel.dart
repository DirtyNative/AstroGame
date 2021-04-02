import 'package:astrogame_app/communications/repositories/species_repository.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:flutter/widgets.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

import 'menu_entry.dart';

@injectable
class MenuViewModel extends BaseViewModel {
  NavigationWrapper _navigationService;

  SpeciesRepository _speciesRepository;
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
    this._speciesRepository,
    this._playerProvider,
  );

  Future navigate(MenuEntry item) async {
    // If already on this page, do nothing
    if (selectedItem == item) {
      return;
    }

    _navigationService.navigateSubTo(item.route);
    notifyListeners();
    //_navigationService.navigateTo(item.route);
  }

  Future<ImageProvider> getSpeciesImageAsync() async {
    var response = await _speciesRepository.getImageAsync(
        speciesId: _playerProvider.getPlayer().playerSpecies.speciesId);

    if (response.hasError) {
      throw Exception(
          'Failed to load species image ${_playerProvider.getPlayer().playerSpecies.speciesId}');
    }

    return response.data;
  }
}
