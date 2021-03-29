import 'package:astrogame_app/enums/dialog_type.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/dialogs/loading_indicator_dialog.dart';
import 'package:flutter/material.dart';
import 'package:injectable/injectable.dart';
import 'package:stacked_services/stacked_services.dart';

@singleton
class DialogHelper {
  DialogService _dialogService;
  NavigationWrapper _navigationService;

  DialogHelper(
    this._navigationService,
  ) {
    _dialogService = new DialogService();
    final builders = {
      DialogType.LoadingIndicator: (context, sheetRequest, completer) =>
          LoadingIndicatorDialog(),
    };
    _dialogService.registerCustomDialogBuilders(builders);
  }

  void showLoadingIndicator() {
    _dialogService.showCustomDialog(
      variant: DialogType.LoadingIndicator,
      barrierDismissible: false,
      barrierColor: Colors.black54,
    );
  }

  void dismissDialog() {
    _navigationService.back();
  }
}
