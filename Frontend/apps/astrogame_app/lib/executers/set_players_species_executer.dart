import 'package:astrogame_app/communications/dtos/add_player_species_request.dart';
import 'package:astrogame_app/communications/repositories/player_repository.dart';
import 'package:astrogame_app/communications/repositories/player_species_repository.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:injectable/injectable.dart';

@injectable
class SetPlayersSpeciesExecuter {
  PlayerRepository _playerRepository;
  PlayerSpeciesRepository _playerSpeciesRepository;

  PlayerProvider _playerProvider;

  DialogHelper _dialogHelper;
  NavigationWrapper _navigationService;

  SetPlayersSpeciesExecuter(
    this._playerRepository,
    this._playerSpeciesRepository,
    this._playerProvider,
    this._dialogHelper,
    this._navigationService,
  );

  Future<bool> addPlayerSpeciesAsync(AddPlayerSpeciesRequest species) async {
    _dialogHelper.showLoadingIndicator();

    var playerSpeciesResponse =
        await _playerSpeciesRepository.addAsync(species);

    // If there happened an error
    if (playerSpeciesResponse.hasError) {
      _dialogHelper.dismissDialog();
      // TODO: show error dialog;
      return false;
    }

    // fetch the player
    var playerResponse = await _playerRepository.getCurrentAsync();

    // If there happened an error
    if (playerResponse.hasError || playerResponse.data == null) {
      _dialogHelper.dismissDialog();
      // TODO: show error dialog;
      return false;
    }

    _playerProvider.setPlayer(playerResponse.data!);

    _dialogHelper.dismissDialog();

    _navigationService.clearStackAndShow(RoutePaths.MainShellRoute);

    return true;
  }
}
