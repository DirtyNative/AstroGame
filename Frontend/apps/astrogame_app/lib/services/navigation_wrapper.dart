import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked_services/stacked_services.dart';

@singleton
class NavigationWrapper {
  late NavigationService _navigationService;

  final GlobalKey subWidgetNavigationKey = new GlobalKey();

  String _currentRoute = '';
  String _previousRoute = '';

  String _currentSubRoute = RoutePaths.HomeRoute;

  NavigationWrapper() {
    _navigationService = new NavigationService();
  }

  String get currentRoute => _currentRoute;
  String get previousRoute => _previousRoute;

  String get currentSubRoute => _currentSubRoute;

  /// Pushes [routeName] onto the navigation stack
  Future<dynamic>? navigateTo(String routeName, {dynamic arguments, int? id}) {
    _previousRoute = _currentRoute;
    _currentRoute = routeName;
    return _navigationService.navigateTo(routeName,
        arguments: arguments, id: id);
  }

  dynamic navigateSubTo(String routeName, {dynamic arguments}) {
    _currentSubRoute = routeName;

    return Navigator.of(subWidgetNavigationKey.currentContext!)
        .pushNamed(routeName, arguments: arguments);
  }

  /// Clears the entire back stack and shows [routeName]
  Future<dynamic>? clearStackAndShow(String routeName,
      {dynamic arguments, int? id}) {
    _previousRoute = _currentRoute;
    _currentRoute = routeName;
    return _navigationService.clearStackAndShow(routeName,
        arguments: arguments, id: id);
  }

  /// Pops the current scope and indicates if you can pop again
  bool back({dynamic result, int? id}) {
    return _navigationService.back(result: result, id: id);
  }
}
