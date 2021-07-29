import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/enums/planet_type.dart';
import 'package:astrogame_app/models/players/colonized_stellar_object.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:astrogame_app/models/stellar/base_types/colonizable_stellar_object.dart';
import 'package:json_annotation/json_annotation.dart';

part 'planet.g.dart';

@GuidConverter()
@NullableGuidConverter()
@JsonSerializable()
class Planet extends ColonizableStellarObject {
  @JsonKey()
  late PlanetType planetType;

  @JsonKey()
  late double scale;

  @JsonKey()
  late double axialTilt;

  @JsonKey()
  List<StellarObjectResource>? resources = [];

  @JsonKey()
  late bool hasHabitableAtmosphere;

  Planet();

  factory Planet.fromJson(Map<String, dynamic> json) => _$PlanetFromJson(json);
  Map<String, dynamic> toJson() => _$PlanetToJson(this);
}
