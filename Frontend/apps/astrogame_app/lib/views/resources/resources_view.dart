import 'package:astrogame_app/configurations/service_locator.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/themes/astrogame_colors.dart';
import 'package:astrogame_app/views/resources/resources_viewmodel.dart';
import 'package:astrogame_app/widgets/scaffold_base.dart';
import 'package:flutter/material.dart';
import 'package:google_nav_bar/google_nav_bar.dart';
import 'package:stacked/stacked.dart';

import 'widgets/resource_view.dart';

class ResourcesView extends StatelessWidget {
  final PageController controller = PageController();

  @override
  Widget build(BuildContext context) {
    return ViewModelBuilder<ResourcesViewModel>.reactive(
      builder: (context, model, _) => ScaffoldBase(
        body: Container(
          child: Column(
            children: [
              Padding(
                padding: const EdgeInsets.only(left: 32, right: 32, top: 32),
                child: _tabWidget(model),
              ),
              Divider(color: Colors.white),
              Expanded(
                child: PageView(
                  controller: controller,
                  onPageChanged: (index) => model.selectedTabIndex = index,
                  children: [
                    _gridView(context, model.elements),
                    _gridView(context, model.buildingMaterials),
                    _gridView(context, model.consumableMaterials),
                    _gridView(context, model.componentMaterials),
                    _gridView(context, model.alloyMaterials),
                    _gridView(context, model.fuelMaterials),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
      viewModelBuilder: () => ServiceLocator.get(),
    );
  }

  Widget _tabWidget(ResourcesViewModel model) {
    return Container(
      child: GNav(
        selectedIndex: model.selectedTabIndex,
        padding: EdgeInsets.all(10),
        gap: 8,
        iconSize: 24,
        color: Colors.white,
        tabBackgroundGradient: LinearGradient(colors: [
          AstroGameColors.purple,
          AstroGameColors.torque,
        ]),
        activeColor: Colors.white,
        textStyle: TextStyle(color: Colors.white),
        tabs: [
          GButton(
            icon: Icons.science_outlined,
            text: 'Elements',
          ),
          GButton(
            icon: Icons.home,
            text: 'Building',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Consumables',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Components',
          ),
          GButton(
            icon: Icons.fastfood,
            text: 'Alloys',
          ),
          GButton(
            icon: Icons.local_gas_station,
            text: 'Fuels',
          ),
        ],
        onTabChange: (index) {
          model.selectedTabIndex = index;
          controller.jumpToPage(index);
        },
      ),
    );
  }

  Widget _gridView(BuildContext context, List<Resource> resourceList) {
    return Padding(
      padding: const EdgeInsets.only(left: 32, right: 32, bottom: 32),
      child: GridView.builder(
        itemBuilder: (context, index) => ResourceView(resourceList[index]),
        itemCount: resourceList.length ?? 0,
        gridDelegate: SliverGridDelegateWithMaxCrossAxisExtent(maxCrossAxisExtent: 300, childAspectRatio: 3 / 1, crossAxisSpacing: 20, mainAxisSpacing: 20),
      ),
    );
  }
}
