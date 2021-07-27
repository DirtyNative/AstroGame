import 'package:astrogame_app/models/players/player.dart';
import 'package:injectable/injectable.dart';

@singleton
class PlayerProvider {
  Player? _player;

  Player? getPlayer() {
    return _player;
  }

  void setPlayer(Player player) {
    _player = player;
  }
}
