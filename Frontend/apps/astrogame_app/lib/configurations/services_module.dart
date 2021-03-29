import 'package:astrogame_app/communications/interceptors/header_interceptor.dart';
import 'package:dio/dio.dart';
import 'package:injectable/injectable.dart';
import 'package:logger/logger.dart';

@module
abstract class ServicesModule {
  //@singleton
  //NavigationService get navigationService;

  @singleton
  Logger get logger => Logger(
        printer: PrettyPrinter(),
        level: Level.error,
      );

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
