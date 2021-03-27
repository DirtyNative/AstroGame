import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/widgets/adaptive_menu.dart';
import 'package:flutter/material.dart';
import 'package:stacked/stacked.dart';

class ScaffoldBase extends StatefulWidget {
  final Widget body;
  final BaseViewModel viewModel;

  ScaffoldBase({@required this.body, @required this.viewModel});

  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<ScaffoldBase> {
  @override
  Widget build(BuildContext context) {
    return AdaptiveMenu(
      child: Scaffold(
        body: GestureDetector(
          child: Container(
            decoration: BoxDecoration(
              color: AstroGameColors.mediumGrey,
              /*image: DecorationImage(
                  image: AssetImage('assets/images/background_2.png'),
                  fit: BoxFit.cover), */
            ),
            child: Stack(
              children: [
                Expanded(child: widget.body),
                AnimatedOpacity(
                  duration: Duration(milliseconds: 300),
                  opacity: widget.viewModel.isBusy ? 1 : 0,
                  child: (widget.viewModel.isBusy)
                      ? _loadingOverlay(context)
                      : SizedBox.shrink(),
                ),
              ],
            ),
          ),
          onTap: () => FocusScope.of(context).unfocus(),
          behavior: HitTestBehavior.opaque,
        ),
      ),
    );
  }

  Widget _loadingOverlay(BuildContext context) {
    return Container(
      color: Colors.black38,
      width: MediaQuery.of(context).size.width,
      height: MediaQuery.of(context).size.height,
      child: Center(
        child: CircularProgressIndicator(),
      ),
    );
  }
}
