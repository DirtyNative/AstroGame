import 'package:astrogame_app/communications/repositories/authorization_repository.dart';
import 'package:astrogame_app/communications/repositories/player_repository.dart';
import 'package:astrogame_app/communications/server_response.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/authorization/authorization_token.dart';
import 'package:astrogame_app/models/authorization/login_request.dart';
import 'package:astrogame_app/models/players/player.dart';
import 'package:astrogame_app/providers/authorization_token_provider.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:astrogame_app/services/hub_service.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:injectable/injectable.dart';
import 'package:tuple/tuple.dart';

@injectable
class LoginExecuter {
  AuthorizationRepository _authorizationRepository;
  PlayerRepository _playerRepository;

  AuthorizationTokenProvider _authorizationTokenProvider;
  PlayerProvider _playerProvider;

  DialogHelper _dialogHelper;
  NavigationWrapper _navigationService;
  HubService _hubService;

  LoginExecuter(
    this._authorizationRepository,
    this._playerRepository,
    this._authorizationTokenProvider,
    this._playerProvider,
    this._dialogHelper,
    this._navigationService,
    this._hubService,
  );

  Future<bool> loginAsync(String email, String password) async {
    _dialogHelper.showLoadingIndicator();

    var loginResponse = await _fetchToken(email, password);
    if (loginResponse.item1 == false) {
      return false;
    }

    // fetch the player
    var playerResponse = await _fetchPlayerAsync();
    if (playerResponse.item1 == false) {
      return false;
    }

    _dialogHelper.dismissDialog();

    // If the user hasn't selected his species, show him a view
    if (playerResponse.item2.data.playerSpecies == null) {
      _navigationService.clearStackAndShow(RoutePaths.SpeciesSelectionRoute);
      return true;
    }

    // Register the hubs
    await _hubService.connectAsync();

    _navigationService.clearStackAndShow(RoutePaths.MainShellRoute);

    return true;
  }

  Future<Tuple2<bool, ServerResponseT<AuthorizationToken>>> _fetchToken(
      String email, String password) async {
    var request = new LoginRequest(email, password);
    var authorizationResponse =
        await _authorizationRepository.loginAsync(request: request);

    // If there happened an error
    if (authorizationResponse.hasError) {
      _dialogHelper.dismissDialog();
      // TODO: show error dialog;
      return Tuple2(false, null);
    }

    // Store the token
    _authorizationTokenProvider.setToken(authorizationResponse.data);

    return Tuple2(true, authorizationResponse);
  }

  Future<Tuple2<bool, ServerResponseT<Player>>> _fetchPlayerAsync() async {
    var playerResponse = await _playerRepository.getCurrentAsync();

    if (playerResponse.hasError) {
      _dialogHelper.dismissDialog();
      // TODO: show error dialog;
      return Tuple2(false, null);
    }

    _playerProvider.setPlayer(playerResponse.data);

    return Tuple2(true, playerResponse);
  }
}
