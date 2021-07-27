import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';

class ScaffoldBase extends StatefulWidget {
  final Widget? body;

  ScaffoldBase({@required this.body});

  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<ScaffoldBase> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: GestureDetector(
        child: Container(
          decoration: BoxDecoration(
            color: AstroGameColors.mediumGrey,
            /*image: DecorationImage(
                  image: AssetImage('assets/images/background_2.png'),
                  fit: BoxFit.cover), */
          ),
          child: widget.body,
        ),
        onTap: () => FocusScope.of(context).unfocus(),
        behavior: HitTestBehavior.opaque,
      ),
    );
  }
}
