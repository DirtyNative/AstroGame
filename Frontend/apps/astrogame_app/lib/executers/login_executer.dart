import 'package:astrogame_app/communications/repositories/authorization_repository.dart';
import 'package:astrogame_app/communications/repositories/player_repository.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/authorization/login_request.dart';
import 'package:astrogame_app/providers/authorization_token_provider.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked_services/stacked_services.dart';

@injectable
class LoginExecuter {
  AuthorizationRepository _authorizationRepository;
  PlayerRepository _playerRepository;

  AuthorizationTokenProvider _authorizationTokenProvider;
  PlayerProvider _playerProvider;

  DialogHelper _dialogHelper;
  NavigationService _navigationService;

  LoginExecuter(
    this._authorizationRepository,
    this._playerRepository,
    this._authorizationTokenProvider,
    this._playerProvider,
    this._dialogHelper,
    this._navigationService,
  );

  Future<bool> loginAsync(String email, String password) async {
    _dialogHelper.showLoadingIndicator();

    var request = new LoginRequest(email, password);
    var authorizationResponse =
        await _authorizationRepository.loginAsync(request: request);

    // If there happened an error
    if (authorizationResponse.hasError) {
      _dialogHelper.dismissDialog();
      // TODO: show error dialog;
      return false;
    }

    // Store the token
    _authorizationTokenProvider.setToken(authorizationResponse.data);

    // fetch the player
    var playerResponse = await _playerRepository.getCurrentAsync();

    // If there happened an error
    if (playerResponse.hasError) {
      _dialogHelper.dismissDialog();
      // TODO: show error dialog;
      return false;
    }

    _playerProvider.setPlayer(playerResponse.data);

    _dialogHelper.dismissDialog();

    // If the user hasn't selected his species, show him a view
    if (playerResponse.data.playerSpecies == null) {
      _navigationService.clearStackAndShow(RoutePaths.SpeciesSelectionRoute);
      return true;
    }

    _navigationService.clearStackAndShow(RoutePaths.StartRoute);

    return true;
  }
}
