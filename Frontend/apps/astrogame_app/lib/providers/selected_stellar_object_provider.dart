import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:injectable/injectable.dart';

@singleton
class SelectedStellarObjectProvider {
  PlayerProvider _playerProvider;

  ColonizedStellarObject _selectedStellarObject;

  SelectedStellarObjectProvider(this._playerProvider);

  ColonizedStellarObject getSelectedStellarObject() =>
      _selectedStellarObject ??
      _playerProvider.getPlayer().colonizedObjects.first;
  void setSelectedStellarObject(ColonizedStellarObject val) =>
      _selectedStellarObject = val;
}
