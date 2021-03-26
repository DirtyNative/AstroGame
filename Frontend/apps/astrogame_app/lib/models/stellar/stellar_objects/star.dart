import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/common/coordinates.dart';
import 'package:astrogame_app/models/enums/star_type.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:astrogame_app/models/stellar/base_types/stellar_object.dart';
import 'package:json_annotation/json_annotation.dart';

part 'star.g.dart';

@GuidConverter()
@JsonSerializable()
class Star extends StellarObject {
  @JsonKey()
  StarType starType;

  @JsonKey()
  double scale;

  @JsonKey()
  double axialTilt;

  @JsonKey()
  List<StellarObjectResource> resources;

  @JsonKey()
  int order;

  Star();

  factory Star.fromJson(Map<String, dynamic> json) => _$StarFromJson(json);
  Map<String, dynamic> toJson() => _$StarToJson(this);
}
