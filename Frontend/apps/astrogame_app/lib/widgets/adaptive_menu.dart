import 'package:astrogame_app/views/menus/menu_view.dart';
import 'package:flutter/material.dart';
import 'package:flutter_inner_drawer/inner_drawer.dart';
import 'package:responsive_builder/responsive_builder.dart';

class AdaptiveMenu extends StatefulWidget {
  final Widget child;

  AdaptiveMenu({@required this.child});

  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<AdaptiveMenu> {
  @override
  Widget build(BuildContext context) {
    return ResponsiveBuilder(
      builder: (context, sizingInformation) {
        if (sizingInformation.deviceScreenType == DeviceScreenType.desktop ||
            sizingInformation.deviceScreenType == DeviceScreenType.tablet) {
          return Row(
            children: [
              Container(
                child: MenuView(),
                width: 300,
              ),
              Expanded(
                child: widget.child,
              ),
            ],
          );
        }

        if (sizingInformation.deviceScreenType == DeviceScreenType.mobile) {
          return InnerDrawer(
            scaffold: widget.child,
            leftChild: MenuView(),
          );
        }

        return SizedBox.shrink();
      },
    );
  }
}
