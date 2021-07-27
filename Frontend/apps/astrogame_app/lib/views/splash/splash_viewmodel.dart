import 'package:astrogame_app/communications/repositories/player_repository.dart';
import 'package:astrogame_app/consts/storage_keys.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/authorization/authorization_token.dart';
import 'package:astrogame_app/models/players/player.dart';
import 'package:astrogame_app/providers/authorization_token_provider.dart';
import 'package:astrogame_app/providers/player_provider.dart';
import 'package:astrogame_app/services/hub_service.dart';
import 'package:astrogame_app/services/local_storage_service.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked/stacked.dart';

@injectable
class SplashViewModel extends FutureViewModel {
  HubService _hubService;
  LocalStorageService _localStorageService;
  NavigationWrapper _navigationWrapper;
  PlayerProvider _playerProvider;
  PlayerRepository _playerRepository;
  AuthorizationTokenProvider _authorizationTokenProvider;

  SplashViewModel(
    this._hubService,
    this._localStorageService,
    this._navigationWrapper,
    this._playerProvider,
    this._playerRepository,
    this._authorizationTokenProvider,
  );

  @override
  Future futureToRun() async {
    await _localStorageService.initAsync();
    var token = await getAccessToken();

    if (token == null) {
      var lastEmail = await _localStorageService
          .readAsync<String>(StorageKeys.lastEmailKey);
      showLoginView(lastEmail);
      return;
    } else {
      // Store the token
      _authorizationTokenProvider.setToken(token);
    }

    var player = await _fetchPlayerAsync();
    if (player == null) {
      _localStorageService.deleteAsync(StorageKeys.tokenKey);
      showLoginView('');
      return;
    }

    // Show species selection
    if (player.playerSpecies == null) {
      showSpeciesSelectionView();
      return;
    }

    // Show Main
    await showMainViewAsync();
  }

  Future<AuthorizationToken?> getAccessToken() async {
    if (await _localStorageService.containsAsync(StorageKeys.tokenKey)) {
      print('exists');
    }
    var token = await _localStorageService.readAsync(StorageKeys.tokenKey);

    if (token == null) {
      return null;
    }

    return AuthorizationToken.fromJson(token);
  }

  void showLoginView(String lastEmail) {
    _navigationWrapper.navigateTo(RoutePaths.LoginRoute, arguments: lastEmail);
  }

  Future<Player?> _fetchPlayerAsync() async {
    var playerResponse = await _playerRepository.getCurrentAsync();

    if (playerResponse.hasError || playerResponse.data == null) {
      return null;
    }

    _playerProvider.setPlayer(playerResponse.data!);

    return playerResponse.data;
  }

  void showSpeciesSelectionView() {
    _navigationWrapper.clearStackAndShow(RoutePaths.SpeciesSelectionRoute);
  }

  Future showMainViewAsync() async {
    await _hubService.connectAsync();

    _navigationWrapper.clearStackAndShow(RoutePaths.MainShellRoute);
  }
}
