import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:injectable/injectable.dart';

@singleton
class SelectedColonizedStellarObjectProvider {
  PlayerProvider _playerProvider;

  ColonizedStellarObject? _selectedObject;

  SelectedColonizedStellarObjectProvider(this._playerProvider);

  ColonizedStellarObject? getSelectedObject() {
    var player = _playerProvider.getPlayer();

    if (player == null) {
      return null;
    }

    if (_selectedObject == null && player.colonizedObjects.length == 0) {
      return null;
    }

    if (_selectedObject == null) {
      return player.colonizedObjects.first;
    }

    return _selectedObject;
  }

  void setSelectedObject(ColonizedStellarObject val) => _selectedObject = val;
}
