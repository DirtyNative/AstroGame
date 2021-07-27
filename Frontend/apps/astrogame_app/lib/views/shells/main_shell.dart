import 'package:astrogame_app/helpers/route_paths.dart';
import 'package:astrogame_app/helpers/router.dart';
import 'package:astrogame_app/services/navigation_wrapper.dart';
import 'package:astrogame_app/views/menus/menu_view.dart';
import 'package:astrogame_app/views/menus/player_colonies_view.dart';
import 'package:astrogame_app/views/menus/resource_view.dart';
import 'package:astrogame_app/widgets/app_header.dart';
import 'package:flutter/material.dart';
import 'package:flutter_inner_drawer/inner_drawer.dart';
import 'package:responsive_builder/responsive_builder.dart';

class MainShell extends StatefulWidget {
  final NavigationWrapper navigationWrapper;

  MainShell(this.navigationWrapper);

  @override
  State<StatefulWidget> createState() => _State();
}

class _State extends State<MainShell> {
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
                child: Column(
                  children: [
                    // The header
                    AppHeader(),

                    //
                    ResourceView(),
                    Expanded(
                      child: Row(
                        children: [
                          Expanded(
                            child: Navigator(
                              onGenerateRoute: generateRoute,
                              initialRoute: RoutePaths.HomeRoute,
                              key: widget
                                  .navigationWrapper.subWidgetNavigationKey,
                            ),
                          ),
                          Container(
                            child: PlayerColoniesView(),
                            width: 200,
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
              ),
            ],
          );
        }

        if (sizingInformation.deviceScreenType == DeviceScreenType.mobile) {
          return InnerDrawer(
            scaffold: SizedBox.shrink(),
            leftChild: MenuView(),
          );
        }

        return SizedBox.shrink();
      },
    );
  }
}
