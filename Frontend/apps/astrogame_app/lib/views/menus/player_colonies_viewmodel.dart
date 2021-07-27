import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/models/players/player.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class PlayerColoniesViewModel extends FutureViewModel {
  PlayerProvider _playerProvider;

  PlayerColoniesViewModel(
    this._playerProvider,
  );

  Player? player;

  List<ColonizedStellarObject> _colonies = [];
  List<ColonizedStellarObject> get colonies => _colonies;
  set colonies(List<ColonizedStellarObject> val) {
    _colonies = val;
    notifyListeners();
  }

  @override
  Future futureToRun() async {
    player = await _fetchPlayerAsync();

    if (player == null) {
      return;
    }

    colonies = player!.colonizedObjects;
  }

  Future<Player?> _fetchPlayerAsync() async {
    return _playerProvider.getPlayer();
  }
}
