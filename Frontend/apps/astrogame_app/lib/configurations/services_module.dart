import 'package:astrogame_app/communications/interceptors/header_interceptor.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked_services/stacked_services.dart';

@module
abstract class ServicesModule {
  @lazySingleton
  NavigationService get navigationService;

  @injectable
  Dio dio(HeaderInterceptor headerInterceptor) =>
      new Dio()..interceptors.add(headerInterceptor);

  /*@lazySingleton
  DialogService get dialogService {
    var dialogServie = new DialogService();

    final builders = {
      DialogType.LoadingIndicator: (context, sheetRequest, completer) =>
          LoadingIndicatorDialog(),
    };

    dialogService.registerCustomDialogBuilders(builders);

    return dialogServie;
  } */
}
