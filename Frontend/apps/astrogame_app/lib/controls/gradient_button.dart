import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:flutter/material.dart';
import 'package:gradient_widgets/gradient_widgets.dart';

class AstroGameGradientButton extends StatelessWidget {
  final Widget child;
  final Function() onPressed;
  final Gradient gradient;

  AstroGameGradientButton({this.child, this.onPressed, this.gradient});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: 180,
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
            padding: const EdgeInsets.all(8.0),
            child: Center(child: child),
          ),
        ),
      ),
    );

    return GradientButton(
      child: child,
      callback: onPressed,
      gradient: LinearGradient(
        colors: [
          AstroGameColors.purple,
          AstroGameColors.torque,
        ],
      ),
    );
  }
}
