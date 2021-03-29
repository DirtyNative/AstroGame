import 'package:injectable/injectable.dart';
import 'package:stacked_services/stacked_services.dart';

@singleton
class NavigationWrapper {
  NavigationService _navigationService;

  String _currentRoute;
  String _previousRoute;

  NavigationWrapper() {
    _navigationService = new NavigationService();
  }

  String get currentRoute => _currentRoute;
  String get previousRoute => _previousRoute;

  /// Pushes [routeName] onto the navigation stack
  Future<dynamic> navigateTo(String routeName, {dynamic arguments, int id}) {
    _previousRoute = _currentRoute;
    _currentRoute = routeName;
    return _navigationService.navigateTo(routeName,
        arguments: arguments, id: id);
  }

  /// Clears the entire back stack and shows [routeName]
  Future<dynamic> clearStackAndShow(String routeName,
      {dynamic arguments, int id}) {
    _previousRoute = _currentRoute;
    _currentRoute = routeName;
    return _navigationService.clearStackAndShow(routeName,
        arguments: arguments, id: id);
  }

  /// Pops the current scope and indicates if you can pop again
  bool back({dynamic result, int id}) {
    return _navigationService.back(result: result, id: id);
  }
}
