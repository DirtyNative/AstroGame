import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class PlayerColoniesViewModel extends BaseViewModel {
  PlayerProvider _playerProvider;

  List<ColonizedStellarObject> get colonies =>
      _playerProvider.getPlayer().colonizedObjects;

  PlayerColoniesViewModel(
    this._playerProvider,
  );
}
