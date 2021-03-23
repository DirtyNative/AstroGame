import 'package:astrogame_app/communications/repositories/authorization_repository.dart';
import 'package:astrogame_app/helpers/dialog_helper.dart';
import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/models/authorization/login_request.dart';
import 'package:astrogame_app/providers/authorization_token_provider.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked_services/stacked_services.dart';

@injectable
class LoginExecuter {
  AuthorizationRepository _authorizationRepository;
  AuthorizationTokenProvider _authorizationTokenProvider;

  DialogHelper _dialogHelper;
  NavigationService _navigationService;

  LoginExecuter(
    this._authorizationRepository,
    this._authorizationTokenProvider,
    this._dialogHelper,
    this._navigationService,
  );

  Future<bool> loginAsync(String email, String password) async {
    _dialogHelper.showLoadingIndicator();

    var request = new LoginRequest(email, password);
    var response = await _authorizationRepository.loginAsync(request: request);

    // If there happened an error
    if (response.hasError) {
      // TODO: show error dialog;
      return false;
    }

    // Store the token
    _authorizationTokenProvider.setToken(response.data);

    _dialogHelper.dismissDialog();

    _navigationService.clearStackAndShow(RoutePaths.StartRoute);

    return true;
  }
}
