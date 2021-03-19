import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';

class AstroGameGradientButton extends StatelessWidget {
  final Widget child;
  final Function() onPressed;
  final Gradient gradient;

  AstroGameGradientButton({this.child, this.onPressed, this.gradient});

  @override
  Widget build(BuildContext context) {
    return ConstrainedBox(
      constraints: BoxConstraints(minWidth: 100, minHeight: 40),
      child: Container(
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(25),
          gradient: LinearGradient(
            colors: [
              AstroGameColors.purple,
              AstroGameColors.torque,
            ],
          ),
        ),
        child: Material(
          color: Colors.transparent,
          child: InkWell(
            borderRadius: BorderRadius.circular(25),
            splashColor: Colors.white10,
            onTap: onPressed,
            child: Padding(
              padding:
                  const EdgeInsets.only(top: 4, bottom: 4, left: 16, right: 16),
              child: Center(child: child),
            ),
          ),
        ),
      ),
    );
  }
}
